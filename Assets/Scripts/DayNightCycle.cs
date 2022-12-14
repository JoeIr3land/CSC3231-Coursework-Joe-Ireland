using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    [SerializeField]
    private float targetDayLength = 0.5f; // in minutes

    [SerializeField, Range(0f, 1f)]
    private float timeOfDay;

    private float timeScale = 100f;

    public bool pause = false;

    [SerializeField]
    private Transform dailyRotation;

    [SerializeField]
    private Light sun;
    private float intensity;
    [SerializeField]
    private float sunBaseIntensity = 1f;
    [SerializeField]
    private float sunVariation = 1.5f;
    [SerializeField]
    private Gradient sunColour;

    private List<DayNightModuleBase> moduleList = new List<DayNightModuleBase>();

    public float getIntensity
    {
        get
        {
            return intensity;
        }
    }


    private void Update()
    {
        if (!pause)
        {
            UpdateTimeScale();
            UpdateTime();
        }
        ChangeSunRotation();
        ChangeSunIntensity();
        ChangeSunColour();

        UpdateModules();
    }

    private void UpdateTimeScale()
    {
        timeScale = 24 / (targetDayLength / 60);
    }

    private void UpdateTime()
    {
        timeOfDay += Time.deltaTime * timeScale / 86400;
        if (timeOfDay > 1)
        {
            timeOfDay -= 1;
        }
    }

    private void ChangeSunRotation()
    {
        float sunAngle = timeOfDay * 360f;
        dailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, sunAngle));
    }

    private void ChangeSunIntensity()
    {
        intensity = Vector3.Dot(sun.transform.forward, Vector3.down);
        intensity = Mathf.Clamp01(intensity);

        sun.intensity = intensity * sunVariation + sunBaseIntensity;
    }

    private void ChangeSunColour()
    {
        sun.color = sunColour.Evaluate(intensity);
    }

    public void AddModule(DayNightModuleBase module)
    {
        moduleList.Add(module);
    }

    public void RemoveModule(DayNightModuleBase module)
    {
        moduleList.Remove(module);
    }

    private void UpdateModules()
    {
        foreach(DayNightModuleBase module in moduleList)
        {
            module.UpdateModule(intensity);
        }
    }
}