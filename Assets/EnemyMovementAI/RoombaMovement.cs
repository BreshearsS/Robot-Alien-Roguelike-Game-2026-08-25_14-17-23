using UnityEngine;
//Code from the "Game Code Library" chanel on YouTube
public class RoombaMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;          //ROTATES THE ENEMY (not used for now)
            //rb.rotation = angle;
        }
    }

    void FixedUpdate()
    {
        if (target)
        {
            rb.linearVelocity = moveDirection * moveSpeed; // use rb.velocity if on an older Unity version
        }
    }
}