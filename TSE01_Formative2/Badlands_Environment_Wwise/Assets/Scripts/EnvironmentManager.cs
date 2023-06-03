using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : AkEnvironment
{
    public enum Environment
    {
        Inside,
        Outside
    }

    public Environment startingEnvironment = Environment.Outside;
    private BoxCollider _collider;

    private void Start()
    {
        _collider = gameObject.GetComponent<BoxCollider>();
        
        if (startingEnvironment == Environment.Inside)
            AkSoundEngine.SetState("InsideOutside", "Inside");
        else if (startingEnvironment == Environment.Outside)
            AkSoundEngine.SetState("InsideOutside", "Outside");
    }
}
