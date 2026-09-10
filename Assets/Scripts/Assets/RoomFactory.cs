using UnityEngine;

public class RoomFactory
{
    private GameData gameData;
    
    public RoomFactory( GameData data )
    {
        gameData = data;
    }
    //Temporary
    public Room GenerateRoom( int x, int y, int depth )
    {
        Room newRoom = new(x*16,y*9);

        //Test
        CreateOuterTestWall( newRoom );

        //Random wall to show rooms are different
        WallSegment randomSegment = Object.Instantiate(gameData.wallPrefab);
        randomSegment.Initialize( new Vector3( newRoom.xPos()+Random.Range(-2,2), newRoom.yPos()+Random.Range(-2,2) ) );
        newRoom.AddWall(randomSegment);

        return newRoom;
    }

    //Create wall around room
    private void CreateOuterTestWall( Room room )
    {
        for(float i = 0; i <= 16; i+=0.5f )
        {
            WallSegment newSegment = Object.Instantiate(gameData.wallPrefab);
            newSegment.Initialize( new Vector3(room.xPos() + i-8f, room.yPos()-4.5f, 0) );
            room.AddWall( newSegment );
            newSegment = Object.Instantiate(gameData.wallPrefab);
            newSegment.Initialize( new Vector3(room.xPos() + i-8f, room.yPos()+4.5f, 0) );
            room.AddWall( newSegment );
        }
        for(float i = 0; i <= 8; i+=0.5f )
        {
            WallSegment newSegment;
            if( i < 2 || i > 3 )
                newSegment = Object.Instantiate(gameData.wallPrefab);
            else
                newSegment = Object.Instantiate(gameData.doorPrefab);

            newSegment.Initialize( new Vector3(room.xPos() -8f, room.yPos()+ i-4f, 0) );
            room.AddWall( newSegment );

            if( i < 2 || i > 3 )
                newSegment = Object.Instantiate(gameData.wallPrefab);
            else
                newSegment = Object.Instantiate(gameData.doorPrefab);

            newSegment.Initialize( new Vector3(room.xPos() + 8f, room.yPos()+ i-4f, 0) );
            room.AddWall( newSegment );
        }
    }
}