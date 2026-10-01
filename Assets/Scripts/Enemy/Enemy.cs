using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Projectile projectile;
    [SerializeField] private float moveSpeed = 2f;

    public float AggroRange { get; set; }
    public float ClosestRange {get; set;}

    private Transform player;

    public void Initialize(Vector3 pos, float aggroRange, float closestRange)
    {
        Debug.Log("Initialize Works");
        transform.position = pos;
        AggroRange = aggroRange;
        ClosestRange = closestRange;

        GameObject p = GameObject.FindWithTag("Player");
        if (p != null) player = p.transform;
    }

    private void Update()
    {
        Debug.Log("void Update working");
        if (player == null) return;
        if(player == null)
        {
            Debug.Log("player == null");
        }

        Vector2 dir = EnemyMovement.GetMoveDirection(transform.position, player.position, AggroRange, ClosestRange);
        transform.position += (Vector3)(dir * moveSpeed * Time.deltaTime);
        Debug.Log(dir + " EnemyMovement is working");
    }
}