using UnityEngine;

public class RoomFactory
{
    private GameData gameData;
    
    public RoomFactory( GameData data )
    {
        gameData = data;
    }
    //Temporary
    public Room GenerateRoom( int depth )
    {
        Room newRoom = new Room(0,0);

        Debug.Log($"Room (in factory): {newRoom}");

        //Test
        CreateOuterTestWall( newRoom );

        Debug.Log($"Room (after walls): {newRoom}");

        return newRoom;
    }

    //Create wall around room
    private void CreateOuterTestWall( Room room )
    {
        for(int i = 0; i < 16; i++ )
        {
            WallSegment newSegment = Object.Instantiate(gameData.wallPrefab);
            newSegment.Initialize( new Vector3(i-7.5f, -3, 0) );
            room.AddWall( newSegment );
            newSegment = Object.Instantiate(gameData.wallPrefab);
            newSegment.Initialize( new Vector3(i-7.5f, 5, 0) );
            room.AddWall( newSegment );
        }
        for(int i = 0; i < 7; i++ )
        {
            WallSegment newSegment;
            if( i < 2 || i > 3 )
                newSegment = Object.Instantiate(gameData.wallPrefab);
            else
                newSegment = Object.Instantiate(gameData.doorPrefab);

            newSegment.Initialize( new Vector3(-7.5f, i-2, 0) );
            room.AddWall( newSegment );

            if( i < 2 || i > 3 )
                newSegment = Object.Instantiate(gameData.wallPrefab);
            else
                newSegment = Object.Instantiate(gameData.doorPrefab);

            newSegment.Initialize( new Vector3(7.5f, i-2, 0) );
            room.AddWall( newSegment );
        }
    }
}