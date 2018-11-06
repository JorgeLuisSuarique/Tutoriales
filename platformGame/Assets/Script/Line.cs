using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Transform go;
    public Transform to;

    void OnDrawGizmosSelected()
    {
        if (go != null && to != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(go.position,to.position);
            Gizmos.DrawSphere(go.position, 0.15f);
            Gizmos.DrawSphere(to.position, 0.15f);
        }
    }
}
