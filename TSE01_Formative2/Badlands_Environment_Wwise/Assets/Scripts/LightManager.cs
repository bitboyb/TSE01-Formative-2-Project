using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private List<StreetLightBehaviour> _streetLights = new List<StreetLightBehaviour>();

    private void Start()
    {
        PopulateList();
    }

    private void PopulateList()
    {
        foreach (var light in GameObject.FindGameObjectsWithTag("Light"))
        {
            _streetLights.Add(light.GetComponent<StreetLightBehaviour>());
            Debug.Log(light.name + "Added to streetLights List sucessfully!");
        }
    }

    public void ToggleLights(bool isNight)
    {
        if (isNight)
        {
            foreach (var light in _streetLights)
            {
                light.PostEvent();
            }
        }
        else if (!isNight)
        {
            foreach (var light in _streetLights)
            {
                light.StopEvent();
            }
        }
    }
}
