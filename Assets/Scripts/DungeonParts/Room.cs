using UnityEngine;
using System.Collections.Generic;

public class Room
{
    private Vector3Int Index {get; set;}

    List<WallSegment> Walls {get; set;}

    public Room( int xIndex, int yIndex )
    {
        Index = new Vector3Int( xIndex, yIndex, 0 );
        Walls = new List<WallSegment>();
    }

    public void AddWall( WallSegment w )
    {
        Walls.Add( w );
    }
}