using UnityEngine;
using System.Collections.Generic;

public class WallSegment : MonoBehaviour
{   
    public void Initialize(Vector3Int pos)
    {
        transform.position = pos;
    }
}