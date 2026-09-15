// using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RoomFactory
{
    private GameData gameData;
    
    public RoomFactory( GameData data )
    {
        gameData = data;
    }
    //Temporary
    public Room GenerateRoom( Vector2Int pos, DoorMaker doors, int depth )
    {
        Room newRoom = new(pos.x*16,pos.y*9);

        AddDoors( newRoom,  doors );
        AddOuterWall( newRoom );

        //Test
        //CreateOuterTestWall( newRoom );

        //Random wall to show rooms are different
        // WallSegment randomSegment = Object.Instantiate(gameData.wallPrefab);
        // randomSegment.Initialize( new Vector3( newRoom.xPos()+Random.Range(-2,2), newRoom.yPos()+Random.Range(-2,2) ) );
        // newRoom.AddWall(randomSegment);

        return newRoom;
    }

    public void AddDoors( Room room, DoorMaker doors )
    {
        foreach( Vector2 door in doors.GetDoors() )
        {
            WallSegment newDoor = Object.Instantiate(gameData.doorPrefab);
            newDoor.Initialize( new Vector3(room.xPos()+door.x,room.yPos()+door.y, 0) );
            if( !room.AddWall( newDoor ) ) UnityEngine.Object.Destroy(newDoor.gameObject);
        }
    }

    //Create wall around room
    private void AddOuterWall( Room room )
    {
        for(float i = 0; i <= 16; i+=0.5f )
        {
            WallSegment newSegment = Object.Instantiate(gameData.wallPrefab);
            newSegment.Initialize( new Vector3(room.xPos() + i-8f, room.yPos()-4.5f, 0) );
            if( !room.AddWall( newSegment ) ) UnityEngine.Object.Destroy(newSegment.gameObject);
            newSegment = Object.Instantiate(gameData.wallPrefab);
            newSegment.Initialize( new Vector3(room.xPos() + i-8f, room.yPos()+4.5f, 0) );
            if( !room.AddWall( newSegment ) ) UnityEngine.Object.Destroy(newSegment.gameObject);
        }
        for(float i = 0; i <= 8; i+=0.5f )
        {
            WallSegment newSegment = Object.Instantiate(gameData.wallPrefab);
            newSegment.Initialize( new Vector3(room.xPos() -8f, room.yPos()+ i-4f, 0) );
            if( !room.AddWall( newSegment ) ) UnityEngine.Object.Destroy(newSegment.gameObject);

            newSegment = Object.Instantiate(gameData.wallPrefab);
            newSegment.Initialize( new Vector3(room.xPos() + 8f, room.yPos()+ i-4f, 0) );
            if( !room.AddWall( newSegment ) ) UnityEngine.Object.Destroy(newSegment.gameObject);
        }
    }
}