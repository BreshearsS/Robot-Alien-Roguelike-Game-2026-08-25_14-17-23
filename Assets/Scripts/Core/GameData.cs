using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data")]
public class GameData : ScriptableObject
{
    public WallSegment wallPrefab;
    public WallSegment doorPrefab;
}