using UnityEngine;

public class FloorFactory
{
    private RoomFactory roomFactory;
    private GameData gameData;

    public FloorFactory( GameData data, RoomFactory factory )
    {
        roomFactory = factory;
        gameData = data;
    }

    //Temporary
    public Floor GenerateFloor( int depth )
    {
        Floor newFloor = new Floor();

        Debug.Log($"RoomFactory: {roomFactory}");
        Debug.Log($"GameData: {gameData}");

        //User room factory here

        //test room
        newFloor.AddRoom( roomFactory.GenerateRoom(depth) );
        // newFloor.AddRoom( new Room(0,0) );

        Debug.Log($"Floor: {newFloor}");

        return newFloor;
    }
    
}