using UnityEngine;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine.UIElements;

public class Floor
{

    private readonly System.Random rng = new System.Random();

    public List<Enemy> Enemies {get; private set;} = new List<Enemy>();
    
    // Biome Biome {get;}

    public List<Room> Rooms {get; private set;} = new List<Room>();

    public void AddRoom( Room r )
    {
        Rooms.Add( r );
    }
    public void AddEnemy( Vector2 pos, GameData data )
    {
        Enemy e = Object.Instantiate(data.roombaPrefab);
        e.Initialize( new Vector2(pos.x*16, pos.y*9),10);
        Enemies.Add(e);
    }

}