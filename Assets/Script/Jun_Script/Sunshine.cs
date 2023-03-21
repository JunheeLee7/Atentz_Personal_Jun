using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunshine : MonoBehaviour
{
    public Material skybox;
    float alpha = 1.0f;
    public float forTimeInGame;  // 시간의 경과

    private bool isNight = false;

    // fog
    public float morningFog;
    public float nightFog;
    public float turnCalc;
    private float density;


    private void Update()
    {
        alpha = alpha - 0.00001f;
        skybox.SetFloat("_CubemapTransition", alpha);
        transform.Rotate(Vector3.right, forTimeInGame * Time.deltaTime); // light의 회전
        SunLight();
        
    }

    void SunLight()
    {
        if (transform.eulerAngles.x >= 170)
        {
            isNight = true;
        }
        else if (transform.eulerAngles.x <= 10)
        {
            isNight = false;
        }

        if (isNight)
        {
            if (density <= nightFog)
            {
                density += turnCalc * Time.deltaTime;
                RenderSettings.fogDensity = density;
            }
        }
        else
        {
            if (density >= morningFog)
            {
                density -= turnCalc * Time.deltaTime;
                RenderSettings.fogDensity = density;
            }
        }
    }
}
