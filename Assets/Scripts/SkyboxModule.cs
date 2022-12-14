using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxModule : DayNightModuleBase
{
    [SerializeField]
    private Gradient skyColour;
    [SerializeField]
    private Gradient groundColour;

    public override void UpdateModule(float intensity)
    {
        RenderSettings.skybox.SetColor("_SkyTint", skyColour.Evaluate(intensity));
        RenderSettings.skybox.SetColor("_GroundColor", groundColour.Evaluate(intensity));
    }
}
