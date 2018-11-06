using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject target;
    public Vector2 minCP, maxCP;
    public float smooth;

    private Vector2 vel;

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref vel.x, smooth);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref vel.y, smooth);
        transform.position = new Vector3(Mathf.Clamp(posX, minCP.x, maxCP.x), Mathf.Clamp(posY, minCP.y, maxCP.y), transform.position.z);
    }
}
