using UnityEngine;
using System.Collections.Generic;

//Temporary object to determine where a door should go in a given pair of rooms

public class DoorMaker
{
    int DoorIndex;
    DoorMaker( bool horizontal )
    {
        if( horizontal )
            DoorIndex = Random.Range(-14,13);
        else
            DoorIndex = Random.Range(-7,5);
    }
}