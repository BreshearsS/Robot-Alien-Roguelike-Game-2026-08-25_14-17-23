using UnityEngine;

public class FloorFactory
{
    //Temporary
    public Floor GenerateFloor()
    {
        Floor newFloor = new Floor();

        newFloor.AddRoom( new Room() );

        return newFloor;
    }
}