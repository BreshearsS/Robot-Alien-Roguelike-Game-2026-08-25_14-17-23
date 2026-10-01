using UnityEngine;
public class EnemyMovement
{
    public Vector2? GetMoveDirection(Vector2 enemyPos, Vector2 playerPos, float aggroRange, float closestRange)
{
        Vector2 toPlayer = playerPos - enemyPos;
        float sqrDist = toPlayer.sqrMagnitude;

        // Out of aggro range: no destination
        if (sqrDist > aggroRange * aggroRange) return null;

        // Already at or inside the preferred distance: no destination
        if (sqrDist <= closestRange * closestRange) return null;

        // Destination is the point on the way to the player at closestRange
        return playerPos - toPlayer.normalized * closestRange;
    }
}