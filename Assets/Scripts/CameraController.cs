using UnityEngine;
using Utils.GenericSingletons;
using DG.Tweening;

public class CameraController : MonoBehaviourSingleton<CameraController>
{
    public void MoveCameraToNextPlatform(Vector2 platformPos)
    {
        Debug.Log("Moving camera to new platform");
        transform
        .DOMoveX(platformPos.x, 1.0f)
        .SetEase(Ease.InOutSine);
    }
}
