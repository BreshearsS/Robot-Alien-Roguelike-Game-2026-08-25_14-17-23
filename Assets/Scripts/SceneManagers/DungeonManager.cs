using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    private GameContext Context;

    public Floor CurrentFloor { get; private set; }
    private int currentDepth;

    private void Awake()
    {
        Context = Initializer.Context;
        currentDepth = 1;
        //CurrentFloor = Context.FloorFactory.GenerateFloor( currentDepth );
    }

    public void CreateNewFloor()
    {
        //CurrentFloor = Context.FloorFactory.GenerateFloor( currentDepth );
    }
}