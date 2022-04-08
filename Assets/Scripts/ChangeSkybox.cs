using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    [SerializeField]
    private Material DarkSpace;
    [SerializeField]
    private Material BlueSky;
    private bool isDarkSpace;

    // [SerializeField]
    // private float a;
    void Start()
    {
        isDarkSpace = false;
    }

    void Update()
    {
    }

    public void ToggleSkybox()
    {
        isDarkSpace = !isDarkSpace;
        SetSkybox();
    }

    private void SetSkybox()
    {
        if (isDarkSpace)
        {
            RenderSettings.skybox = DarkSpace;
            // RenderSettings.skybox.Lerp(BlueSky, DarkSpace, a * Time.deltaTime);
        }
        else
        {
            RenderSettings.skybox = BlueSky;
            // RenderSettings.skybox.Lerp(DarkSpace, BlueSky, a * Time.deltaTime);
        }
    }
}
