using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float speed = 20f;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<RoombaExplode>(out var roomba))
        {
            roomba.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
