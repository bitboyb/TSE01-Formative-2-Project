using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerAudioBehaviour : AkEnvironment
{
    private string _stateName = "InsideOutside", _insideState = "Inside", _outsideState = "Outside";
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("First person controller full");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player)
            AkSoundEngine.SetState(_stateName, _insideState);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == _player)
            AkSoundEngine.SetState(_stateName, _outsideState);
    }
}
