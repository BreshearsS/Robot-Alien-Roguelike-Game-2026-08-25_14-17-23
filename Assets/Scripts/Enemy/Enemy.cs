using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Projectile projectile;
    public float AggroRange {get; set;}
    public void Initialize(Vector3 pos, float AggroRange)
    {
        transform.position = pos;
    }
}

