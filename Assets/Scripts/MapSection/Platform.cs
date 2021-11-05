using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private ColliderController enterNextPlatformCollider;

    [SerializeField] private SpriteRenderer spriteComp;
    [SerializeField] private Transform enterPos;


    void Awake()
    {
        enterNextPlatformCollider.onTriggerEnter.AddListener(OnLeavePlatform);
    }

    private void OnLeavePlatform(Collider2D other)
    {
        if (other.gameObject == Player.instance.gameObject)
        {
            enterNextPlatformCollider.onTriggerEnter.RemoveAllListeners();
            GameLoopManager.instance.HandlePlayerOnReachEndOfPlatform();
        }
    }


    public void SetPosAfterPrevPlatform(Vector2 prevPlatformPos)
    {
        float newXPos = prevPlatformPos.x - 13.0f;
        transform.position = new Vector2(newXPos, prevPlatformPos.y);
    }

    public Vector2 GetEnterPos() => enterPos.position;

    public Vector2 GetPlatformSize() => spriteComp.bounds.size;
}
