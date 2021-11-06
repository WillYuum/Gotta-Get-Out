using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private ColliderController enterNextPlatformCollider;
    [SerializeField] private Transform playerStartPos;
    private MeshFilter meshFilterComp;


    void Awake()
    {
        meshFilterComp = gameObject.GetComponent<MeshFilter>();
        enterNextPlatformCollider.onTriggerEnter.AddListener(OnLeavePlatform);
    }

    private void OnLeavePlatform(Collider other)
    {
        if (other.gameObject == Player.instance.gameObject)
        {
            enterNextPlatformCollider.onTriggerEnter.RemoveAllListeners();
            GameLoopManager.instance.HandlePlayerOnReachEndOfPlatform();
        }
    }

    public Vector2 GetEnterPos() => playerStartPos.position;

    public Vector2 GetPlatformSize() => gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size;
}
