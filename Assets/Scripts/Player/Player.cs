using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Touched something");
        if (other.CompareTag("Projectile"))
        {
            Projectile shot = other.GetComponent<Projectile>();
            GetHitBy(shot);
        }
    }

    void GetHitBy( Projectile p )
    {
        Debug.Log("Hit by: " + p);
    }
}
