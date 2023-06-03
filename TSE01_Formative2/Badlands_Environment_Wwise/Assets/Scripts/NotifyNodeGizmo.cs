using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyNodeGizmo : MonoBehaviour
{
    public float maxAttenuation;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, maxAttenuation);
    }
}
