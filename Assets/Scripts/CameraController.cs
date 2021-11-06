using UnityEngine;
using Utils.GenericSingletons;
using DG.Tweening;

public class CameraController : MonoBehaviourSingleton<CameraController>
{

    void Start()
    {
        // FitOrthoSizeToPlatformSize();
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
        Vector3 platformSize = MapController.instance.GetGeneralPlatformSize();
        print("Platform size " + platformSize);
        Camera.main.orthographicSize = 7 * Screen.height / Screen.width * 0.5f;
    }

}
