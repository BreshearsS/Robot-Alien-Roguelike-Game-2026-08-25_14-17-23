using UnityEngine;

public class RoombaMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float pauseDuration = 0.5f;   
    public float dashDuration = 1f;    

    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;
    private Vector3 direction;
    private Vector3 targetPos;
    private float PauseTimer;
    private bool IsDashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PauseTimer = pauseDuration;
        IsDashing = false;
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()//-------------------------------------------------------------|
    {
        if (!target) return; //AI

        PauseTimer -= Time.deltaTime;

        if (IsDashing)
        {
            if (PauseTimer <= 0f)
            {
                IsDashing = false;
                PauseTimer = pauseDuration;                                             //mostly writen by me but had some help from AI
                moveDirection = Vector2.zero;
            }
        }
        else
        {
            if (PauseTimer <= 0f)
            {
                direction = (target.position - transform.position).normalized;
                moveDirection = direction;

                IsDashing = true;           //AI]
                PauseTimer = dashDuration;    //]
            }
        }//---------------------------------------------------------------------|

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;              //ROTATES THE ENEMY (not used for now)
        //rb.rotation = angle;
    }

    void FixedUpdate()
    {
        if (target)
        {
            rb.linearVelocity = moveDirection * moveSpeed;
        }
    }
}