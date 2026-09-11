using System.Collections.Generic;
using Unity.VisualScripting;
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


    //Creating a floor:
    // The starting room will be the elevator, which will appear to stay the same between levels (figure this out later).
    // From there, the path leads down to a 'foyer'. Then, a path will be drawn to the boss chamber.
    // The boss chamber will be a number of rooms from the foyer. The generator will continue stepping randomly until it gets to the required distance, at which point the boss room will be placed.
    // Each time the generater steps, it creates a room. It also creates a DoorMaker between the rooms which knows where the door will be that joins them.
    // After drawing a line to the boss chamber, a second path will be walked from the boss back to the elevator. This will hopefully prevent the creation of a single, linear path.
    // Only one DoorMaker can exist between two rooms - conflicts will be consolidated.
    // If the boss stepper takes too long, it will be restarted.
    // Idea: The return stepper will walk randomly, but with every step it will become more likely to move toward the foyer instead of away from it.
    // Moving into the elevator will never be allowed.

    // Once the paths have been drawn (stored as a series of coordinates), these will be made into rooms.
    // Distance to boss will be the sum of the absolute values of the x and y indices of the steps on a plane that begins at 0,-1 (elevator is 0,0)
    // Distance required will be depth+4 (for now)

    //Temporary
    public Floor GenerateFloor( int depth )
    {
        Floor newFloor = new Floor();

        List<Vector2Int> Path = DrawPaths(1);

        foreach( Vector2Int step in Path )
            newFloor.AddRoom( RoomFactory.GenerateRoom( step, depth) );

        //User room factory here
        // //test room
        // newFloor.AddRoom( RoomFactory.GenerateRoom(-2,0,depth) );
        // newFloor.AddRoom( RoomFactory.GenerateRoom(-1,0,depth) );
        // newFloor.AddRoom( RoomFactory.GenerateRoom(0,0,depth) );
        // newFloor.AddRoom( RoomFactory.GenerateRoom(1,0,depth) );
        // newFloor.AddRoom( RoomFactory.GenerateRoom(2,0,depth) );
        // newFloor.AddRoom( RoomFactory.GenerateRoom(0,1,depth) );
        // newFloor.AddRoom( new Room(0,0) );

        return newFloor;
    }
    
    private List<Vector2Int> DrawPaths( int depth )
    {
        //Steps away from elevator before reaching boss room
        int goal = depth+4;

        //Current step on path
        Vector2Int CurrentStep = new(0,-1);

        //Path to be returned
        List<Vector2Int> path = new() { CurrentStep };

        //Keep stepping until reaching goal or going on too long
        while( ( Mathf.Abs(CurrentStep.x) + Mathf.Abs(CurrentStep.y) < goal) )
        {
            Vector2Int PossibleStep;

            do
            {
                int dir = Random.Range(1,4);
                if( dir == 1 )      PossibleStep = new Vector2Int( CurrentStep.x+1, CurrentStep.y );
                else if( dir == 2 ) PossibleStep = new Vector2Int( CurrentStep.x-1, CurrentStep.y );
                else if( dir == 3 ) PossibleStep = new Vector2Int( CurrentStep.x, CurrentStep.y+1 );
                else                PossibleStep = new Vector2Int( CurrentStep.x, CurrentStep.y-1 );
            }
            while( ( PossibleStep.x == 0 && PossibleStep.y == 0 ) ); //Can't go to elevator

            //Add new random step
            CurrentStep = PossibleStep;
            path.Add(CurrentStep);

            //Went on too long - reset
            if( path.Count > goal*20 )
            {
                CurrentStep = new(0,-1);
                path = new() {CurrentStep };
            }
        }

        //Remove duplicates (I think this works, edited code from reddit and it APPEARS to work...)
        path = new( path.DistinctBy(item => new {item.x, item.y, }) );
        return path;
    }
}