using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    List<WallSegment> Walls {get; set;}

    private void Awake()
    {
        Walls = new List<WallSegment>();
        CreateOuterTestWall();
    }

    private void CreateOuterTestWall()
    {
        for(int i = 0; i < 15; i++ )
        {
            Walls.Add( new WallSegment() );
        }
    }
}