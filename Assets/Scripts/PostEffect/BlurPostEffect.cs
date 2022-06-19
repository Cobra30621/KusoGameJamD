using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurPostEffect : MonoBehaviour
{
    public Material mat;

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, mat);
    }
}
