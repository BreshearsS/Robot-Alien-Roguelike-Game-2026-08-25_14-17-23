using UnityEngine;
//Made using YouTube video guide
[RequireComponent(typeof(RoombaMovement))]
public class IdleState : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private Animator animator;

    private RoombaMovement roombaMovement;

    private void Awake()
    {
        roombaMovement = GetComponent<RoombaMovement>();
        roombaMovement.enabled = false; // stay idle until player is close

        if (animator == null)
            animator = GetComponent<Animator>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) player = playerObj.transform;
        }
    }

    private void OnEnable()
    {
        if (animator != null)
            animator.SetBool("IsChasing", false);
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= detectionRange)
        {
            SwapToChase();
        }
    }

    private void SwapToChase()
    {
        if (animator != null)
            animator.SetBool("IsChasing", true);

        roombaMovement.enabled = true;
        enabled = false; // turn off idle logic
    }
}