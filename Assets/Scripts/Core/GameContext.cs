using UnityEngine;

// This object will be persistent (not destroyed on load) and will contain
//    useful operations and objects such as factories, as well as objects
//    that need to persist such as the player.

public class GameContext
{
    public RoomFactory RoomFactory {get;}
    public FloorFactory FloorFactory {get;}

    // Player player {get;};


    public GameContext( GameData data )
    {
        //instantiate factories
        RoomFactory = new RoomFactory( data );
        FloorFactory = new FloorFactory( data, RoomFactory );
    }
}