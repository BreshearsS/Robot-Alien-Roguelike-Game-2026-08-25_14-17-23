using UnityEngine;

public class DungeonManager : MonoBehavoir
{
    private GameContext Context;

    private Floor CurrentFloor { get; private set; }
    private int currentDepth;

    private void Awake()
    {
        Context = Initializer.Context;
        currentDepth = 1;
        CurrentFloor = Context.FloorFactory.generateFloor( currentDepth );
    }

    public void CreateNewFloor()
    {
        CurrentFloor = Context.FloorFactory.generateFloor( currentDepth );
    }
}