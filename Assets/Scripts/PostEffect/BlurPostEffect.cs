using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurPostEffect : MonoBehaviour
{
    public Material mat;

    public void SetEffectAttritube(float lastTime)
    {
        float amount = Mathf.InverseLerp(0, 10, lastTime);
        Debug.Log(amount);
        mat.SetFloat("_WaveLength", Mathf.Lerp(0.01f,1.0f,amount));
        mat.SetFloat("_WaveAmplitude", Mathf.Lerp(0.02f, 0.2f, 1-amount));
        //mat.SetFloat("_WaveSpeed", Mathf.Lerp(15.01f, 90.0f, 1-amount));
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, mat);
    }
}
