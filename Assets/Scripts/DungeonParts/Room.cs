using UnityEngine;
using System.Collections.Generic;
using System;

public class Room
{
    private Vector3Int Position {get; set;}
    public Rect Boundary {get; private set;}

    List<WallSegment> Walls {get; set;}

    public Room( int xIndex, int yIndex )
    {
        Position = new Vector3Int( xIndex, yIndex, 0 );
        Walls = new List<WallSegment>();
        Boundary = new Rect( Position.x-8, Position.y-3.5f, 16, 9 );
    }

    public bool AddWall( WallSegment w )
    {
        //Do not add if a wall segment already exists there
        foreach( WallSegment wall in Walls )
            if( wall.transform.position == w.transform.position )
                return false;

        Walls.Add( w );
        return true;
    }

    public int xPos()
    {
        return Position.x;
    }
    public int yPos()
    {
        return Position.y;
    }

    public bool Contains( Vector2 position )
    {
        return Boundary.Contains(position);
    }
}