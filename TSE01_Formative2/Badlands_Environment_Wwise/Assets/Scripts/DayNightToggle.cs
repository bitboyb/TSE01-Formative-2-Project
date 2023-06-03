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
    public string onNight, onDay;
    private NotifyManager _notifyManager;
    private AmbienceManager _ambManager;
    private LightManager _lightManager;

    void Start()
    {
        _ambManager = GameObject.Find("AudioManager").GetComponent<AmbienceManager>();
        _lightManager = GameObject.Find("AudioManager").GetComponent<LightManager>();
        
        RenderSettings.skybox = skyBoxToggle;

        newLightIntensityMultiplier = 1f;
        
        newSkyColor = dayColor;
        newSkybox = daySkybox;
        newFogColor = dayFogColor;

        nightLightArr = GetComponentsInChildren<Light>();
        Debug.Log("Night Light Array Length = " + nightLightArr.Length);

        targetRotation = sunObject.transform.rotation;
        _notifyManager = GameObject.Find("NotifyManager").GetComponent<NotifyManager>();

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
            if (newIntensity != lightIntensityDay)
            {
                AkSoundEngine.PostEvent(onDay, _notifyManager.GetClosestNode());
                _ambManager.SetTimeOfDay(AmbienceManager.TimeOfDay.Day);
                _lightManager.ToggleLights(false);
            }
            
            newIntensity = lightIntensityDay;

            newLightIntensityMultiplier = lightIntensityMultiplierDay;

            newSkyColor = dayColor;

            newSkybox = daySkybox;

            newFogColor = dayFogColor;

            SetBlendedEulerAngles(currentRotation = new Vector3(sunDay, -859, -391));

            //Wwise set global DayNight RTPC to 0
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (newIntensity != lightIntensityNight)
            {
                AkSoundEngine.PostEvent(onNight, _notifyManager.GetClosestNode());
                _ambManager.SetTimeOfDay(AmbienceManager.TimeOfDay.Night);
                _lightManager.ToggleLights(true);
            }
            
            newIntensity = lightIntensityNight;

            newLightIntensityMultiplier = lightIntensityMultiplierNight;

            newSkyColor = nightColor;

            newSkybox = nightSkybox;

            newFogColor = nightFogColor;

            SetBlendedEulerAngles(currentRotation = new Vector3(sunNight, -859, -391));

            //Wwise set global DayNight RTPC to 1
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
