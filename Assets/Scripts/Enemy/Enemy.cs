using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Projectile projectile;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float acceleration = 15f;
    [SerializeField] private float slowRadius = 3f;
    public float AggroRange { get; set; }
    public float ClosestRange {get; set;}

    private Transform player;
    private EnemyMovement enemyMovement;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.linearDamping = 1f;
        rb.gravityScale = 0f;
    }
    public void Initialize(Vector3 pos, float aggroRange, float closestRange)
    {
        transform.position = pos;
        AggroRange = aggroRange;
        ClosestRange = closestRange;
        enemyMovement = new();
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null) player = p.transform;
        else Debug.LogWarning("Enemy could not find 'Player'");
    }

    //FixedUpdate() and MoveTowardPlayer() were made using the help of Claude (AI).
    private void FixedUpdate()
    {
        if (player == null || enemyMovement == null) return;

               
        Vector2? target = enemyMovement.GetMoveDirection(rb.position, player.position, AggroRange, ClosestRange);

        MoveTowardPlayer(target);
    }

    private void MoveTowardPlayer(Vector2? target)
    {
        Vector2 desiredVelocity = Vector2.zero;

        if (target.HasValue)
        {
            Vector2 toTarget = target.Value - rb.position;
            float dist = toTarget.magnitude;

            // Full speed far away, easing to zero as we arrive
            float breakingSpeed = moveSpeed * Mathf.Clamp01(dist / slowRadius);
            desiredVelocity = toTarget.normalized * breakingSpeed;
        }

        // Steer current velocity toward desired velocity, limited by acceleration.
        // With no target, desiredVelocity is zero, so this acts as braking.
        Vector2 velocityChange = desiredVelocity - rb.linearVelocity;
        Vector2 accel = Vector2.ClampMagnitude(velocityChange / Time.fixedDeltaTime, acceleration);

        rb.AddForce(accel * rb.mass, ForceMode2D.Force);
    }

    /*
    private void Update()
    {
        if (player == null) return;
        if(player == null)
        {
            Debug.Log("player == null");
        }

        Vector2 dir = enemyMovement.GetMoveDirection(transform.position, player.position, AggroRange, ClosestRange);
        transform.position += (Vector3)(dir * moveSpeed * Time.deltaTime);
    }*/
}