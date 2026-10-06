using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data")]
public class GameData : ScriptableObject
{
    //Room Parts
    public WallSegment wallPrefab;
    public WallSegment doorPrefab;

    //Enemy Types
    public Enemy TestEnemy;

    Dictionary<Biome, List<Enemy>> Robots = new Dictionary<Biome, List<Enemy>>();
    Dictionary<Biome, List<Enemy>> Aliens = new Dictionary<Biome, List<Enemy>>();

    public void Initialize()
    {
        Robots.Clear();
        Aliens.Clear();

        //Add all robots
        foreach (Enemy e in Resources.LoadAll<Enemy>("EnemyPrefabs/Robots"))
        {
            if (e.faction == Faction.ROBOT) //Make sure it's a robot
            {
                //Create new section in dictionary for Biome if it doesn't exist
                if (!Robots.ContainsKey(e.biome))
                    Robots.Add(e.biome, new());

                //Add enemy to that biome list
                Robots[e.biome].Add(e);
            }
        }

        //Add all aliens
        foreach (Enemy e in Resources.LoadAll<Enemy>("EnemyPrefabs/Aliens"))
        {
            if (e.faction == Faction.ALIEN) //Make sure it's an alien
            {
                //Create new section in dictionary for Biome if it doesn't exist
                if (!Aliens.ContainsKey(e.biome))
                    Aliens.Add(e.biome, new());

                //Add enemy to that biome list
                Aliens[e.biome].Add(e);
            }
        }
    }

    //TODO: Choose an enemy of appropriate danger level
    public Enemy RandomEnemy( Faction f, Biome b, int danger )
    {
        Enemy ChosenEnemy;
        //Choose appropriate list
        Dictionary<Biome,List <Enemy>> EnemyDict = f == Faction.ROBOT ? Robots : Aliens;

        //Limit search time
        for (int i = 0; i < 100; i++)
        {
            ChosenEnemy = EnemyDict[b][Random.Range(0, EnemyDict[b].Count)];
            //Make sure enemy is not outside danger level
            if (ChosenEnemy.DifficultyLevel <= danger)
                return ChosenEnemy;
        }

        //Ideally, will never happen
        return null;
    }
}

public enum Biome
{
    LAB, BIO, COLD,
    NONE
}