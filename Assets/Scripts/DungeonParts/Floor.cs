using UnityEngine;
using System.Collections.Generic;

public class Floor
{
    // List<Enemy> Enemies {get;}
    
    // Biome Biome {get;}

    public List<Room> Rooms {get; private set;}

    public void AddRoom( Room r )
    {
        Rooms.Add( r );
    }
}