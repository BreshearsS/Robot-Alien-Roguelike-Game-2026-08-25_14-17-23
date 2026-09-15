using UnityEngine;
using System.Collections.Generic;

//Temporary object to determine where doors should go in a given pair of rooms

public class DoorMaker
{
    Vector2 EastDoor, WestDoor, NorthDoor, SouthDoor;
    //         1         2          3          4

    public void AddEntrance( int dir )
    {
        switch( dir )
        {
            case 2: if( EastDoor == Vector2.zero )  EastDoor  = new Vector2(  8, Random.Range(-14,13) ); break;
            case 1: if( WestDoor == Vector2.zero )  WestDoor  = new Vector2( -8, Random.Range(-14,13) ); break;
            case 4: if( NorthDoor == Vector2.zero ) NorthDoor = new Vector2( Random.Range(-7,5),  4.5f ); break;
            case 3: if( SouthDoor == Vector2.zero ) SouthDoor = new Vector2( Random.Range(-7,5), -4.5f ); break;
        }
    }
    public void AddExit( int dir )
    {
        switch( dir )
        {
            // case 1: if( EastDoor == null )  EastDoor  = new Vector2( Random.Range(-14,13), -4 ); break;
            // case 2: if( WestDoor == null )  WestDoor  = new Vector2( Random.Range(-14,13),  4 ); break;
            // case 3: if( NorthDoor == null ) NorthDoor = new Vector2(  5.5f, Random.Range(-7,5) ); break;
            // case 4: if( SouthDoor == null ) SouthDoor = new Vector2( -5.5f, Random.Range(-7,5) ); break;
            case 1: if( EastDoor == Vector2.zero )  EastDoor  = new Vector2(  8, Random.Range(-14,13) ); break;
            case 2: if( WestDoor == Vector2.zero )  WestDoor  = new Vector2( -8, Random.Range(-14,13) ); break;
            case 3: if( NorthDoor == Vector2.zero ) NorthDoor = new Vector2( Random.Range(-7,5),  4.5f ); break;
            case 4: if( SouthDoor == Vector2.zero ) SouthDoor = new Vector2( Random.Range(-7,5), -4.5f ); break;
        }
    }

    // Return list of doors positions (with extra door tile on each side, for a 3-wide door)
    public List<Vector2> GetDoors()
    {
        List<Vector2> DoorList = new List<Vector2>();

        //FOR TESTING - KEEP DOORS LINED UP
        EastDoor.y = 0;
        WestDoor.y = 0;
        NorthDoor.x = 0;
        SouthDoor.x = 0;

        if( EastDoor != Vector2.zero )
        {
            DoorList.Add( new Vector2(EastDoor.x, EastDoor.y-0.5f) );
            DoorList.Add( new Vector2(EastDoor.x, EastDoor.y  ) );
            DoorList.Add( new Vector2(EastDoor.x, EastDoor.y+0.5f) );
        }

        if( WestDoor != Vector2.zero )
        {
            DoorList.Add( new Vector2(WestDoor.x, WestDoor.y-0.5f) );
            DoorList.Add( new Vector2(WestDoor.x, WestDoor.y  ) );
            DoorList.Add( new Vector2(WestDoor.x, WestDoor.y+0.5f) );
        }

        if( NorthDoor != Vector2.zero )
        {
            DoorList.Add( new Vector2(NorthDoor.x-0.5f, NorthDoor.y) );
            DoorList.Add( new Vector2(NorthDoor.x,      NorthDoor.y) );
            DoorList.Add( new Vector2(NorthDoor.x+0.5f, NorthDoor.y) );
        }

        if( SouthDoor != Vector2.zero )
        {
            DoorList.Add( new Vector2(SouthDoor.x-0.5f, SouthDoor.y) );
            DoorList.Add( new Vector2(SouthDoor.x,      SouthDoor.y) );
            DoorList.Add( new Vector2(SouthDoor.x+0.5f, SouthDoor.y) );
        }

        return DoorList;
    }
}