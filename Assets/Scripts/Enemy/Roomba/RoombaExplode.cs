using UnityEngine;
//Made using YouTube video guide
public class ExplodingEnemy : MonoBehaviour
{
    [Header("Explosion Settings")]
    public float destroyDelay = 0.5f;
    public float explodeRadius = 1.5f;
    public float damageRadius = 3f;
    public int damage = 25;
    public GameObject explosionEffectPrefab;
    public LayerMask damageableLayers;

    [Header("References")]
    public Transform player;
    public Animator animator;

    private bool hasExploded = false;

    void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
            else
                Debug.LogWarning("ExplodingEnemy: No player found. Assign one in the Inspector or tag your player 'Player'.");
        }
    }

    void Explode()
    {
        hasExploded = true;

        if (animator != null)
        {
            animator.SetTrigger("Explode");
        }

        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        Collider[] hits = Physics.OverlapSphere(transform.position, damageRadius, damageableLayers);
        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent<Damageable>(out var damageable))
            {
                damageable.TakeDamage(damage);
            }
        }

        Destroy(gameObject, destroyDelay);
    }

    void Update()
    {
        if (hasExploded || player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= explodeRadius)
        {
            Explode();
        }
    }
}