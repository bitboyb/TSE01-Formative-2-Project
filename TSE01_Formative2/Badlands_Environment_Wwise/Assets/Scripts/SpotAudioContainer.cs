using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ColourPreset
{
    public enum Preset
    {
        Green,
        Blue,
        Yellow,
        Cyan,
        Magenta
    }

    public Preset preset;

    public Color Color
    {
        get
        {
            switch (preset)
            {
                case Preset.Blue:
                    return Color.blue;
                case Preset.Green:
                    return Color.green;
                case Preset.Yellow:
                    return Color.yellow;
                case Preset.Cyan:
                    return Color.cyan;
                case Preset.Magenta:
                    return Color.magenta;
                default:
                    return Color.white;
            }
        }
    }
}

public class SpotAudioContainer : MonoBehaviour
{
    [SerializeField] private ColourPreset colourPreset;
    
    public string spotAudioEvent;
    [Range(0,100)] public int maxAttenuation;
    public bool isDebugMode;
    

    private void Start()
    {
        if (spotAudioEvent == "" && isDebugMode)
            AkSoundEngine.PostEvent(AudioDebug.TestLoopEvent3D, gameObject);
        else
            AkSoundEngine.PostEvent(spotAudioEvent, gameObject);
    }

    private void OnDrawGizmos()
    { 
        if (spotAudioEvent == "")
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = colourPreset.Color;
        }
        Gizmos.color = colourPreset.Color;
        Gizmos.DrawWireSphere(transform.position, maxAttenuation);
    }

    private void OnDestroy()
    {
        AkSoundEngine.StopAll(gameObject);
    }
}