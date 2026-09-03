using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    [SerializeField] private WallSegment prefabSegment;
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
            WallSegment newSegment = Instantiate(prefabSegment);
            newSegment.Initialize( new Vector3Int(i-7, -4, 0) );
            Walls.Add( newSegment );
            newSegment = Instantiate(prefabSegment);
            newSegment.Initialize( new Vector3Int(i-7, 4, 0) );
            Walls.Add( newSegment );
        }
        for(int i = 0; i < 7; i++ )
        {
            WallSegment newSegment = Instantiate(prefabSegment);
            newSegment.Initialize( new Vector3Int(-7, i-3, 0) );
            Walls.Add( newSegment );
            newSegment = Instantiate(prefabSegment);
            newSegment.Initialize( new Vector3Int(7, i-3, 0) );
            Walls.Add( newSegment );
        }
    }
}