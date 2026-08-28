using UnityEngine;
//Made with the help of YouTube
public class RoombaController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform player;
    [SerializeField] private float chaseRange = 8f;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        bool isChasing = distance <= chaseRange;

        animator.SetBool("isChasing", isChasing);
    }
}