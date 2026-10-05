using UnityEngine;
public class EnemyMovement
{
    public Vector2? GetMoveDirection(Vector2 enemyPos, Vector2 playerPos, float aggroRange, float prefRange)
{
        Vector2 toPlayer = playerPos - enemyPos;
        float sqrDist = toPlayer.sqrMagnitude;

        // Out of aggro range
        if (sqrDist > aggroRange * aggroRange) return null;

        // Already at or inside the preferred distance
        if (sqrDist == prefRange * prefRange) return null;

        // Destination is the point on the way to the player at prefRange
        return playerPos - toPlayer.normalized * prefRange;
    }
}