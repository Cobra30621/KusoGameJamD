using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Linq;

public static class SoundManagerInitialization
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Init()
    {
        GameObject.DontDestroyOnLoad(GameObject.Instantiate(Resources.Load("SoundManager")));
    }
}

public class SoundManager : MonoBehaviour
{
    static public SoundManager Instance = null;

    //����
    Dictionary<Sound, SoundPack> soundBank = new Dictionary<Sound, SoundPack>();
    [SerializeField] AudioSource sfxPlayer;
    [SerializeField] List<SoundPack> soundList = new List<SoundPack>();
    //����
    Dictionary<Music, MusicPack> musicBank = new Dictionary<Music, MusicPack>();
    [SerializeField] AudioSource musicPlayer;
    [SerializeField] List<MusicPack> musicList = new List<MusicPack>();

    [SerializeField] AudioMixerSnapshot maxVolume;
    [SerializeField] AudioMixerSnapshot minVolume;
    [SerializeField] AudioMixerSnapshot drunk;

    Music currentMusic = Music.None;
    bool isPreventPlayback = false;
    Coroutine prevenPlayback;

    /// <summary>�Ω󼽩�ݭn�j�q�ӷL�ܤƪ��n��(ex.�}�B�n)</summary>
    List<SoundPack> collectedSounds = new List<SoundPack>();

    bool hasSubscribeSceneChange = false;

    private void Awake()
    {

        //��l�ƭ��Įw
        soundBank.Clear();
        foreach (SoundPack s in soundList)
        {
            soundBank.Add(s.sound, s);
        }
        //��l�ƭ��֮w
        musicBank.Clear();
        foreach (MusicPack m in musicList)
        {
            musicBank.Add(m.music, m);
        }
        Instance = this;
    }


    private void Start()
    {

        StartCoroutine(PlayMusic(musicList[0].music));
    }


    #region ����


    IEnumerator PlayMusic(Music music)
    {

        if (!musicBank.ContainsKey(music) || musicBank[music].audioClip == null )
            yield break;

        while (true)
        {
            //����񤧫e�����֡A�ñNmixer���q���̧ܳC
            musicPlayer.Stop();
            yield return null;
            minVolume.TransitionTo(0f);
            yield return null;
            //�}�l����ḛ̀Ѽ�FadeIn
            musicPlayer.clip = musicBank[music].audioClip;
            musicPlayer.volume = musicBank[music].volume;
            musicPlayer.Play();
            maxVolume.TransitionTo(musicBank[music].fadeIn);
            //�������FadeOut�I      
            yield return new WaitUntil(() => (musicPlayer.clip.length - musicPlayer.time) <= musicBank[music].fadeOut);
            minVolume.TransitionTo(musicBank[music].fadeOut);
            yield return new WaitForSeconds(musicBank[music].fadeOut);
        }
    }

    void StopMusic(Music music)
    {
        minVolume.TransitionTo(musicBank[music].fadeOut);
    }

    #endregion


    #region ����
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="sound"></param>
    public void Play(Sound sound)
    {
        StartCoroutine(PlayOnce(sound,0f));
    }

    /// <summary>
    /// ����
    /// <para>preventTime:����Ӯɶ�������A����</para>
    /// </summary>
    /// <param name="sound"></param>
    /// <param name="preventTime"></param>
    public void Play(Sound sound,float preventTime)
    {
        StartCoroutine(PlayOnce(sound,preventTime));
    }

    /// <summary>
    /// ������������w�a�I����
    /// </summary>
    /// <param name="sound"></param>
    /// <param name="position"></param>
    public void Play(Sound sound, Vector3 position = default(Vector3))
    {
        StartCoroutine(PlayInScene(sound, position));
    }


    private IEnumerator PlayOnce(Sound sound,float preventTime = 0.1f)
    {
        sfxPlayer.clip = null;
        yield return new WaitForSeconds(soundBank[sound].offset);
        if (isPreventPlayback)
            yield break;

        sfxPlayer.PlayOneShot(soundBank[sound].clip, soundBank[sound].volume);
        if(preventTime > 0)
            prevenPlayback = StartCoroutine(PreventPlaybackTime(preventTime));
    }

    private IEnumerator PlayInScene(Sound sound, Vector3 pos)
    {
        yield return new WaitForSeconds(soundBank[sound].offset);
        AudioSource.PlayClipAtPoint(soundBank[sound].clip, pos, soundBank[sound].volume);
    }


    /// <summary>
    /// ����UI����
    /// </summary>
    /// <param name="sound"></param>
    public void PlayWithUI(Sound sound)
    {
        sfxPlayer.clip = soundBank[sound].clip;
        sfxPlayer.Play();
    }

    private void PlayRandomizedSound(Sound sound)
    {

    }

    public void Stop()
    {
        sfxPlayer.Stop();
    }

    private void Stop(Sound sound)
    {
        sfxPlayer.Stop();
    }

    #endregion

    IEnumerator PreventPlaybackTime(float time)
    {
        isPreventPlayback = true;
        yield return new WaitForSeconds(time);
        isPreventPlayback = false;
    }

    public void PlayEndSound(Sound sound){
        sfxPlayer.PlayOneShot(soundBank[sound].clip); 
        Debug.Log($"Play:{sound}");
    }


    public void PlayPointerEvent(Sound sound, bool isPointerUp)
    {
        if (isPreventPlayback || !soundBank.ContainsKey(sound) || soundBank[sound].clip == null)
            return;

        if (isPointerUp)
            sfxPlayer.PlayOneShot(soundBank[sound].pointerUpClip); 
        else
            sfxPlayer.PlayOneShot(soundBank[sound].clip);
        

        prevenPlayback = StartCoroutine(PreventPlaybackTime(0.2f));
    }

    public void Drunk(bool isDrunk)
    {
        if (isDrunk)
            drunk.TransitionTo(5f);
        else
            maxVolume.TransitionTo(0.1f);
    }


}



public enum Sound
{
    Sing, TakeSign, DirtyJoke, Game,
    LoveLetter, Wine,Shit,StartGame,ExitGame, StopDrunk, Hello,
    DirtyJokeEnd, WineEnd, GameEnd, LoveFailEnd, LoveSuccessEnd, SingEnd
}

public enum Music
{
    None,
    MainGame,
    Menu,
    JudgeEnd, KusoEnd, WineEnd, LeaveEnd
}


[System.Serializable]
public struct SoundPack
{
    public AudioClip clip;
    public AudioClip pointerUpClip;
    public Sound sound;
    [Range(0f, 1f)] public float volume;
    [Range(0f, 3f)] public float offset;
}

[System.Serializable]
public struct MusicPack
{
    public AudioClip audioClip;
    public Music music;
    public int sceneIndex;
    [Range(0f, 1f)] public float volume;
    public float fadeIn;
    public float fadeOut;
}