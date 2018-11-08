using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingModel : MonoBehaviour
{
    private PolygonCollider2D pc2d;
    private EnemyContrller controller;
    private Animator animator;

    private void OnBecameInvisible()
    {
        pc2d.enabled = false;
        controller.maxSpeed = 0;
        controller.speed = 0;
        animator.enabled = false;
    }

    private void OnBecameVisible()
    {
        pc2d.enabled = true;
        controller.maxSpeed = 1;
        controller.speed = 3.5f;
        animator.enabled = true;
    }

    private void Awake()
    {
        pc2d = transform.GetComponent<PolygonCollider2D>();
        controller = transform.GetComponent<EnemyContrller>();
        animator = transform.GetComponent<Animator>();
    }
}
