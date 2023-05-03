using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightToggle : MonoBehaviour
{
    public Material daySkybox;
    public Material nightSkybox;
    public Material skyBoxToggle;
    private Material newSkybox;
    private Material currentSkybox;

    public Light sunLight;
    public GameObject sunObject;

    public Color dayColor;
    public Color nightColor;
    private Color newSkyColor;

    private Component[] nightLightArr;

    private float newIntensity;

    private float newLightIntensityMultiplier;
    private float currentLightIntensityMultiplier;

    private Quaternion targetRotation = Quaternion.identity;
    private Vector3 currentRotation;

    public Color dayFogColor;
    public Color nightFogColor;
    private Color newFogColor;

    public AK.Wwise.RTPC wwiseDayNightRTPC;

    void Start()
    {
        RenderSettings.skybox = skyBoxToggle;

        newLightIntensityMultiplier = 1f;
        
        newSkyColor = dayColor;
        newSkybox = daySkybox;
        newFogColor = dayFogColor;

        nightLightArr = GetComponentsInChildren<Light>();
        Debug.Log("Night Light Array Length = " + nightLightArr.Length);

        targetRotation = sunObject.transform.rotation;

    }

    void Update()
    {
        DayToNightToggle();
    }

    void DayToNightToggle()
    {
        float lightIntensityDay = 0f;
        float lightIntensityNight = 4f;

        float lightIntensityMultiplierDay = 1f;
        float lightIntensityMultiplierNight = 0.1f;

        float sunDay = 128.5f;
        float sunNight = 158.1f;

        currentLightIntensityMultiplier = RenderSettings.ambientIntensity;

        if (Input.GetKeyDown(KeyCode.T))
        {
            newIntensity = lightIntensityDay;

            newLightIntensityMultiplier = lightIntensityMultiplierDay;

            newSkyColor = dayColor;

            newSkybox = daySkybox;

            newFogColor = dayFogColor;

            SetBlendedEulerAngles(currentRotation = new Vector3(sunDay, -859, -391));

            //Wwise set global DayNight RTPC to 0
            wwiseDayNightRTPC.SetGlobalValue(0);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            newIntensity = lightIntensityNight;

            newLightIntensityMultiplier = lightIntensityMultiplierNight;

            newSkyColor = nightColor;

            newSkybox = nightSkybox;

            newFogColor = nightFogColor;

            SetBlendedEulerAngles(currentRotation = new Vector3(sunNight, -859, -391));

            //Wwise set global DayNight RTPC to 1
            wwiseDayNightRTPC.SetGlobalValue(1);
        }

        currentSkybox = skyBoxToggle;

        //Toggles each Light components Intensity inside the array
        foreach (Light light in nightLightArr)
        {
            light.intensity = Mathf.Lerp(light.intensity, newIntensity, Time.deltaTime / 3);
        }

        //Change light color and lerps between skyboxes
        sunLight.color = Color.Lerp(sunLight.color, newSkyColor, Time.deltaTime / 3);
        RenderSettings.skybox.Lerp(currentSkybox, newSkybox, Time.deltaTime / 5);

        //Change light intensity multiplier 
        RenderSettings.ambientIntensity = Mathf.Lerp(currentLightIntensityMultiplier, newLightIntensityMultiplier, Time.deltaTime / 4);

        //Set Fog color
        RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, newFogColor, Time.deltaTime / 3);

        //Rotate directional light to new position
        sunObject.transform.rotation = Quaternion.RotateTowards(sunObject.transform.rotation, targetRotation, Time.deltaTime * 3);

    }

    //Sets the new directional light position
    public void SetBlendedEulerAngles(Vector3 angles)
    {
        targetRotation = Quaternion.Euler(angles);
    }
}
