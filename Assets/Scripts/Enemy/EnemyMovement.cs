using System;
using System.Numerics;
using UnityEditor.Rendering;
using Random = UnityEngine.Random;

public class EnemyMovement
{
    Boolean enemyAggroed = false;
    Player target;
    Enemy enemy;
    public void Initialize(Player target, Enemy enemy)
    {
        if(targetPos < enemy.AggroRange)
        {
            Idle();
        }
        else if(targetPos >= enemy.AggroRange)
        {
            enemyAggroed = true;
            MoveTowardsPlayer();
        }
    }

    void Idle()
    {
        //Picks random position and moves to it
        float direction = Random.Range(1,5);
    }

    void MoveTowardsPlayer()
    {
        //moves towards palyer.
    }

}
