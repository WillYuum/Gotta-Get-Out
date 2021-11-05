using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Platform platform;


    public Platform GetPlatform() => platform;

    public void SetPosAfterPrevLevel(Vector2 prevLevelPos)
    {
        float newXPos = prevLevelPos.x - 23.0f;
        transform.position = new Vector2(newXPos, prevLevelPos.y);
    }
}
