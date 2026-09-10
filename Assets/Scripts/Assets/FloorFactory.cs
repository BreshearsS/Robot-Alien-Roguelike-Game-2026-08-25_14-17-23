using UnityEngine;

public class FloorFactory
{
    private RoomFactory RoomFactory;
    private GameData GameData;

    public FloorFactory( GameData data, RoomFactory factory )
    {
        RoomFactory = factory;
        GameData = data;
    }

    //Temporary
    public Floor GenerateFloor( int depth )
    {
        Floor newFloor = new Floor();

        //User room factory here

        //test room
        newFloor.AddRoom( RoomFactory.GenerateRoom(-32,0,depth) );
        newFloor.AddRoom( RoomFactory.GenerateRoom(-16,0,depth) );
        newFloor.AddRoom( RoomFactory.GenerateRoom(0,0,depth) );
        newFloor.AddRoom( RoomFactory.GenerateRoom(16,0,depth) );
        newFloor.AddRoom( RoomFactory.GenerateRoom(32,0,depth) );
        // newFloor.AddRoom( new Room(0,0) );

        return newFloor;
    }
    
}