using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LocationTriggerBehaviour : MonoBehaviour
{
    private AmbienceManager _ambManager;
    private GameObject _player;

    private void Start()
    {
        _ambManager = GameObject.Find("AudioManager").GetComponent<AmbienceManager>();
        _player = GameObject.Find("First person controller full");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player)
            _ambManager.SelectLocation(AmbienceManager.Location.InTown);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == _player)
            _ambManager.SelectLocation(AmbienceManager.Location.OutOfTown);
    }
}
