using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurPostEffect : MonoBehaviour
{
    public Material mat;
    public Texture2D noiseTex;

    void Start()
    {
        mat.SetTexture("_NoiseTex", noiseTex);
    }

    void FixedUpdate()
    {
        // Scale speed of water droplets
        mat.SetFloat("_NoiseOffset", Time.time * 0.05f);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, mat);
    }
}
