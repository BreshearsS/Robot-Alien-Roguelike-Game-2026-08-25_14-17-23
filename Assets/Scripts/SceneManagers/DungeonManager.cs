//ChatGPT Used to figure out how to re-position camera

using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    private GameContext Context;

    public Floor CurrentFloor { get; private set; }
    public Room CurrentRoom { get; private set; }
    private int currentDepth;

    [SerializeField] public PlayerController TestPlayer;

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
        CurrentRoom = CurrentFloor.Rooms[0];
        SnapCameraTo(CurrentRoom);
    }

    public void CreateNewFloor()
    {
        //CurrentFloor = Context.FloorFactory.GenerateFloor( currentDepth );
    }

    private void SnapCameraTo( Room r )
    {
        Camera.main.transform.position = new Vector3( r.xPos(), r.yPos(), -10 );
    }

    private void Update()
    {
        if( !CurrentRoom.Contains(TestPlayer.transform.position) )
            foreach( Room r in CurrentFloor.Rooms )
                if( r.Contains(TestPlayer.transform.position) )
                {
                    CurrentRoom = r;
                    SnapCameraTo( r );
                    // Camera.main.transform.position = new Vector3( r.xPos(), r.yPos(), -10 );
                    break;
                }

    }
}