using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyManager : MonoBehaviour
{
    private List<GameObject> _notifyNodes = new List<GameObject>();
    private Transform _listenerTransform;
    private float _lastDistance, _tooCloseDistance =25;
    private GameObject _closestNode;

    private void Start()
    {
        _listenerTransform = GameObject.Find("First person controller full").GetComponent<Transform>();
        PopulateList();
    }

    public GameObject GetClosestNode()
    {
        _lastDistance = 100.0f;
        
        foreach (var node in _notifyNodes)
        {
            float distance = Vector3.Distance(node.transform.position, _listenerTransform.position);
            Debug.Log("Distance = " + distance);
            
            if (distance <= _lastDistance && distance > _tooCloseDistance)
                CacheNode(distance, node);
            if (distance < _tooCloseDistance)
                return null;
        }
        return _closestNode;
    }

    private void CacheNode(float distance, GameObject node)
    {
        _lastDistance = distance;
        _closestNode = node;
    }

    private void PopulateList()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        foreach (var child in allChildren)
        {
            _notifyNodes.Add(child.gameObject);
            Debug.Log(child.gameObject.name + " Sucessfully Added To Notify List");
        }
        
        Debug.Log(_notifyNodes.Count + " Is List Max Index");
    }
}
