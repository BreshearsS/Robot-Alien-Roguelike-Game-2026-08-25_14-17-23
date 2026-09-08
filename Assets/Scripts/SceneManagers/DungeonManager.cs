//ChatGPT Used to figure out how to re-position camera

using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    private GameContext Context;

    public Floor CurrentFloor { get; private set; }
    public Room CurrentRoom { get; private set; }
    private int currentDepth;

    //Vertical Size of game window
    private const float WindowHeight = 9f;

    private void Awake()
    {
        Context = Initializer.Context;

        Camera camera = Camera.main;       // Get a reference
        camera.orthographicSize = 4.5f;    // Modify the referenced Camera

        // CurrentFloor = new Floor();

        // CurrentRoom.setRoom( new Room(0,0) ); <- HOW???
        // AddComponent( new Room(0,0) );

        currentDepth = 1;
        
        CurrentFloor = Context.FloorFactory.GenerateFloor( currentDepth );
    }

    public void CreateNewFloor()
    {
        //CurrentFloor = Context.FloorFactory.GenerateFloor( currentDepth );
    }
}