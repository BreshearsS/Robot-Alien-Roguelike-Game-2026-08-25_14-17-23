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
        foreach (Enemy e in Resources.LoadAll<Enemy>("Robots"))
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
        foreach (Enemy e in Resources.LoadAll<Enemy>("Aliens"))
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

    public Enemy RandomEnemy( Faction f, Biome b )
    {
        switch (f)
        {
            case Faction.ROBOT: return RandomRobot(b);
            case Faction.ALIEN: return RandomAlien(b);
            default: return null;
        }
    }

    private Enemy RandomRobot(Biome b)
    {
        return Robots[b][Random.Range(0, Robots[b].Count)];
    }

    private Enemy RandomAlien(Biome b)
    {
        return Aliens[b][Random.Range(0, Robots[b].Count)];
    }
}

public enum Biome
{
    LAB, BIO, COLD,
    NONE
}