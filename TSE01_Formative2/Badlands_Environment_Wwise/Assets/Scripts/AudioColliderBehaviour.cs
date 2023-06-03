using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioColliderBehaviour : MonoBehaviour
{
    private float _timer;
    private Transform _listenerTransform;
    
    public string colliderEvent;
    public float minimumInterval = 30.0f, maxInterval = 50.0f;
    [Range(0, 100)] public float attenuation = 10.0f;
    [Range(1, 7)] public int probability = 3;

    private void Start()
    {
        _listenerTransform = GameObject.Find("First person controller full").GetComponent<Transform>();
        ResetTimer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        AkSoundEngine.PostEvent(colliderEvent, gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        AkSoundEngine.PostEvent(colliderEvent, gameObject);
    }

    private void Update()
    {
        if (Vector3.Distance(_listenerTransform.position, transform.position) <= attenuation)
        {
            //Debug.Log("Player not within range of " + gameObject.name + ". Not playing random sound!);
            return;
        }

        _timer -= Time.deltaTime;
        //Debug.Log(_timer + gameObject.name);

        if (_timer <= 0f)
        {
            var diceRoll = Random.Range(1, 7);
            
            if (diceRoll <= probability)
            {
                AkSoundEngine.PostEvent(colliderEvent, gameObject);
                Debug.Log("Random Sound Being Played = " + gameObject.name + " & " + colliderEvent);
                ResetTimer();
            }
            else
            {
                Debug.Log("Random Sound did not play!");
                ResetTimer();
            }
        }
    }

    private void ResetTimer()
    {
        _timer = Random.Range(minimumInterval, maxInterval);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, attenuation);
    }
}
