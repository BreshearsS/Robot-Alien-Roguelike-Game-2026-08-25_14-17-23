using UnityEngine;
using System.Collections.Generic;

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

    public void AddWall( WallSegment w )
    {
        Walls.Add( w );
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