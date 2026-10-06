using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Scripting.LifecycleManagement.CodeGen;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

//Got the idea to use switch statements from AI, however the code was writen by a human

/*
receives room, floor, and tokens
just needs to receive biome
*/


//generateAliens() <-- Still need to do this

//public enum EnemyType
//{
//    Roomba = 1,
//    Turret = 2,
//    MissileRobot = 3

//}


public class EnemyFactory
{
    private GameData GameData;

    public GameObject roombaPrefab;
    public GameObject turretPrefab; // doesn't exist yet
    public GameObject missilePrefab; // also doesn't exist yet
    
    public EnemyFactory(GameData data)
    {
        GameData = data;
    }

    //GameData.RandomEnemy( Faction f, Biome b, int difficulty );

    // Gets the highest enemy type for each floor
    Enemy GetMaxEnemyType(int floor) // this will change later whenever we get biomes working
    {
        switch (floor)
        {
            case 1:
            case 2:
                return GameData.RandomEnemy(Faction.ROBOT, Biome.LAB, 1);
                //return EnemyType.Turret;  // roombas, turrets
            default:
                return GameData.RandomEnemy(Faction.ROBOT, Biome.LAB, 1);
                //return EnemyType.MissileRobot; // floor 3+: roombas, turrets, missiles
        }
    }

    int GetCost(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Roomba:  return 1; // the only one that can spawn so then everything doesnt break 
            case EnemyType.Turret:  return 69; // cost is 1 (69 is just for testing)
            case EnemyType.MissileRobot: return 420; // cost is 2 (420 is just for testing)
            default: return 0;
        }
    }

    GameObject GetPrefab(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Roomba:  return roombaPrefab;
            case EnemyType.Turret:  return turretPrefab;
            case EnemyType.MissileRobot: return missilePrefab;
            default: return null;
        }
    }

    public List<GameObject> GetRobotList(Room room, int floor, int tokens)
    {
        List<GameObject> enemies = new List<GameObject>();
        int maxType = (int)GetMaxEnemyType(floor);

        while (tokens > 0)
        {
            EnemyType randEnemy = (EnemyType)Random.Range(1, maxType + 1);
            int cost = GetCost(randEnemy);

            if (cost > tokens)
            {
                continue; // can't afford it, so it rerolls
            }
            else
            {
                enemies.Add(GetPrefab(randEnemy));
                tokens -= cost; 
            }
        }

        return enemies;
    }

    public List<GameObject> GetAlienList(Room room, int floor, int toekns)
    {
        //Will do the same thing as GetRobotList but with aliens
        return null;
    }
}