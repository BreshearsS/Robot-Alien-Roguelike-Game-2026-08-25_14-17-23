using UnityEngine;


public class Initializer : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    public static GameContext Context { get; private set; }

    private void Awake()
    {
        //Suggested by ChatGPT
        if (Context != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Context = new GameContext(gameData);
    }
}