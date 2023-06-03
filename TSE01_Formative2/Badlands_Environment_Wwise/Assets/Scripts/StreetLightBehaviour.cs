using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StreetLightBehaviour : MonoBehaviour
{
    public string lightEvent;
    [Range(0, 100)] public float attenuation = 15;

    public void PostEvent()
    {
        AkSoundEngine.PostEvent(lightEvent, gameObject);
    }

    public void StopEvent()
    {
        AkSoundEngine.StopAll(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attenuation);
    }
}
