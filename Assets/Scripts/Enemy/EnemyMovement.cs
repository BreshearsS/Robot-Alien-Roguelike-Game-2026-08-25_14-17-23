using UnityEngine;
public static class EnemyMovement
{
    public static Vector2 GetMoveDirection(Vector2 enemyPos, Vector2 playerPos, float aggroRange, float closestRange)
    {
        Vector2 toPlayer = playerPos - enemyPos;
        float sqrDist = toPlayer.sqrMagnitude;

        // Out of range, or when the enemy reaches their "I don't want to go any closer" range
        if (sqrDist > aggroRange * aggroRange || sqrDist < closestRange)
            return Vector2.zero;

        return toPlayer.normalized;
    }
}