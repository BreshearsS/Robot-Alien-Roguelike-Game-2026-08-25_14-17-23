using UnityEngine;
//Made using YouTube video guide
public class RoombaExplode : MonoBehaviour
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

    [Header("Enemy Stats")]
    public int maxHealth = 100;
    private int currentHealth = 69420;

    private bool hasExploded = false;

    void Start()
    {
        currentHealth = maxHealth;
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
            else
                Debug.LogWarning("ExplodingEnemy: No player found. Assign one in the Inspector or tag your player 'Player'.");
        }
    }

    public void TakeDamage(int amount)
    {
        if (hasExploded) return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Explode();
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

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, damageRadius, damageableLayers);

        foreach (Collider2D hit in hits)
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