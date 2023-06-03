using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    public enum Location
    {
        InTown,
        OutOfTown
    }
    
    public enum TimeOfDay
    {
        Day,
        Night
    }
    
    private Location _location;
    private TimeOfDay _timeOfDay;
    private string _rtpcName = "Day/Night",  _switchName = "Location", _outOfTown = "OutOfTown", _inTown = "InTown";
    
    public string ambienceEvent;
    
    private void Start()
    {
        AkSoundEngine.PostEvent(ambienceEvent, gameObject);
        
        SetTimeOfDay(TimeOfDay.Day);
        SelectLocation(Location.OutOfTown);
    }

    public void SelectLocation(Location location)
    {
        if (location == Location.InTown)
        {
            _location = location;
            AkSoundEngine.SetState(_switchName, _inTown);
            Debug.Log("Location set to " + location);
        }
        else if (location == Location.OutOfTown)
        {
            _location = location;
            AkSoundEngine.SetState(_switchName, _outOfTown);
            Debug.Log("Location set to " + location);
        }
        else
        {
            Debug.Log("Invalid location input!");
        }
    }

    public void SetTimeOfDay(TimeOfDay timeOfDay)
    {
        if (timeOfDay == TimeOfDay.Day)
        {
            StartCoroutine(LerpRTPCValue(_rtpcName, 0f, 1f, 2f));
            Debug.Log("Time Of Day is set to " + timeOfDay);
        }
        else if (timeOfDay == TimeOfDay.Night)
        {
            StartCoroutine(LerpRTPCValue(_rtpcName, 1f, 0f, 2f));
            Debug.Log("Time Of Day is set to " + timeOfDay);
        }
        else
        {
            Debug.Log("Invalid timeOfDay input!");
        }
    }
    
    private IEnumerator LerpRTPCValue(string rtpcName, float startValue, float targetValue, float duration)
    {
        float startTime = Time.time;
        float elapsedTime = 0f;
        
        while (elapsedTime < duration)
        {
            float t = Mathf.Clamp01(elapsedTime / duration);
            float lerpedValue = Mathf.Lerp(startValue, targetValue, t);
            
            AkSoundEngine.SetRTPCValue(rtpcName, lerpedValue, gameObject);
            
            elapsedTime = Time.time - startTime;
            yield return null;
        }
        
        AkSoundEngine.SetRTPCValue(rtpcName, targetValue, gameObject);
    }
}