using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.Image;

public class Projectile : MonoBehaviour
{
    [SerializeField] public int Cooldown;
    [SerializeField] private float Lifespan;
    [SerializeField] private int Speed;

    private float EndTime { get; set; }
    private Vector3 Movement { get; set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EndTime = Time.time + Lifespan;
        //Figured with help from ChatGPT
        Movement = (GameObject.Find("Player").transform.position - this.transform.position).normalized * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Movement;

        if (Time.time >= EndTime)
            Destroy(gameObject);
    }
}
