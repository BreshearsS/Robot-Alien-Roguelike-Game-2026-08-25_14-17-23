using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.Image;

public class Projectile : MonoBehaviour
{
    [SerializeField] public int Cooldown;
    [SerializeField] private float Lifespan;
    [SerializeField] private float Speed;

    private float EndTime { get; set; }
    private Vector3 Movement { get; set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EndTime = Time.time + Lifespan;
        //Figured with help from ChatGPT
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        Movement = (target.transform.position - transform.position).normalized * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Movement;

        if (Time.time >= EndTime)
            Destroy(gameObject);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
