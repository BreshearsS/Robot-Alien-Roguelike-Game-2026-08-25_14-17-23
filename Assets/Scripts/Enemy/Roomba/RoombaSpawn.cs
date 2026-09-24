using UnityEngine;
using Random = UnityEngine.Random;

public class RoombaSpawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject roombaPrefab;

    [SerializeField] private float minSpawnDistance = 1.0f;
    [SerializeField] private float maxSpawnDistance = 3.0f;

    private void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
            else
                Debug.LogWarning("RoombaSpawn: No player assigned and none found with tag 'Player'.");
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        if (player == null || roombaPrefab == null) return;

        Vector3 spawnPosition = GetSpawnPositionAroundPlayer();
        Instantiate(roombaPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetSpawnPositionAroundPlayer()
    {
        // Random distance between min and max
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);

        // Random direction around the player (2D circle)
        float angle = Random.Range(0f, Mathf.PI * 2f);
        Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;

        return player.position + new Vector3(offset.x, offset.y, 0f);
    }
}