using UnityEngine;
using Utils.GenericSingletons;
using DG.Tweening;

public class CameraController : MonoBehaviourSingleton<CameraController>
{

    void Awake()
    {
        FitOrthoSizeToPlatformSize();
    }


    public void MoveCameraToNextPlatform(Vector2 platformPos)
    {
        Debug.Log("Moving camera to new platform");
        transform
        .DOMoveX(platformPos.x, 1.0f)
        .SetEase(Ease.InOutSine);
    }


    private void FitOrthoSizeToPlatformSize()
    {
        Vector2 platformSize = MapController.instance.GetGeneralPlatformSize();
        Camera.main.orthographicSize = platformSize.x * Screen.height / Screen.width * 0.5f;
    }

}
