using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.InferenceEngine.Tokenization.PostProcessors;
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
    //public int CurrentDepth { get; private set; }
    
    public EnemyFactory(GameData data) //DungeonManager currentDepth
    {
        GameData = data;
        //depth = currentDepth;
    }

    //GameData.RandomEnemy( Faction f, Biome b, int difficulty );

    // Gets the highest enemy type for each floor
    Enemy GetMaxEnemyType(int CurrentDepth) // this will change later whenever we get biomes working
    {
        switch (CurrentDepth)
        {
            case 1:
            case 2:
                return GameData.RandomEnemy(Faction.ROBOT, Biome.LAB, CurrentDepth);
                //return EnemyType.Turret;  // roombas, turrets
            default:
                return GameData.RandomEnemy(Faction.ROBOT, Biome.LAB, CurrentDepth);
                //return EnemyType.MissileRobot; // floor 3+: roombas, turrets, missiles
        }
    }

    //int GetCost(EnemyType type)
    //{
    //    switch (type)
    //    {
    //        case EnemyType.Roomba:  return 1; // the only one that can spawn so then everything doesnt break 
    //        case EnemyType.Turret:  return 100; // cost is 1 (100 is just for testing)
    //        case EnemyType.MissileRobot: return 100; // cost is 2 (100 is just for testing)
    //        default: return 0;
    //    }
    //}

    //GameObject GetPrefab(EnemyType type)
    //{
    //    switch (type)
    //    {
    //        case EnemyType.Roomba:  return roombaPrefab;
    //        case EnemyType.Turret:  return turretPrefab;
    //        case EnemyType.MissileRobot: return missilePrefab;
    //        default: return null;
    //    }
    //}


    public List<Enemy> MakeAllRobots(Room room, int depth, int roomTokens)
    {
        List<Enemy> enemies = new List<Enemy>(); // temp
        return enemies;                          // temp
    }

    private void DistributeTokens(List<Room> rooms, int tokens)
    {
        foreach(Room r in rooms) r.tokens++;
        while(tokens > 0)
        {
            int randRoom = Random.Range(0, rooms.Count);  // 0 to amount of rooms
            rooms[randRoom].tokens++;                     // Gives the rooms tokens back to room
            tokens--;
        }
    }


    private List<Enemy> GetRobotList(Room room, int depth, int roomTokens)
    {
        List<Enemy> enemies = new List<Enemy>();
        //int maxType = CurrentDepth / 2 + 1;// (int)GetMaxEnemyType(floor);
        int stopCounter = 0;
        while (roomTokens > 0 && stopCounter < 50)
        {
            //EnemyType randEnemy = (EnemyType)Random.Range(1, maxType + 1);
            Enemy randEnemy = Object.Instantiate(GameData.RandomEnemy(Faction.ROBOT, Biome.LAB, depth));
            int cost = randEnemy.TokenCost;//GetCost(randEnemy);

            if (cost > roomTokens)
            {
                stopCounter++;
                continue; // can't afford it, so it rerolls 
            }
            else
            {
                //enemies.Add(GetPrefab(randEnemy));
                randEnemy.Initialize(new Vector2(room.xPos(), room.yPos()));
                enemies.Add(randEnemy);
                roomTokens -= cost;
            }
        }

        return enemies;
    }

    public List<GameObject> GetAlienList(Room room, int floor, int roomTokens)
    {
        //Will do the same thing as GetRobotList but with aliens
        return null;
    }
}