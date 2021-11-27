using UnityEngine;
using Utils.GenericSingletons;
using DG.Tweening;

public class CameraController : MonoBehaviourSingleton<CameraController>
{
    public void MoveCameraToNextPlatform(Vector2 platformPos)
    {
        Debug.Log("Moving camera to new platform");

        //1.92f is the distance between the camera and the platform
        float endPosX = platformPos.x + (-1.92f);

        transform
        .DOMoveX(endPosX, 1.0f)
        .SetEase(Ease.InOutSine);
    }
}
