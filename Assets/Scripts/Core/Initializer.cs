using UnityEngine;

public class Initializer : MonoBehaviour
{
    public static GameContext Context { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        Context = new GameContext();
    }
}