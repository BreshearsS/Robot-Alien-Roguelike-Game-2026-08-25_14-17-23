import UnityEngine;

public class FloorFactory
{
    //Temporary
    public Floor GenerateFloor()
    {
        Floor newFloor = new Floor();

        newFloor.addRoom( new Room() );

        return newFloor;
    }
}