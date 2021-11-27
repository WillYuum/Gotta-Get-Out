using UnityEngine;

[ExecuteInEditMode]
public class CameraFit : MonoBehaviour
{
    [SerializeField] private float height = 1.0f;



    void Update()
    {
        SetFitHeight();
    }

    public void SetFitHeight()
    {
        Camera.main.orthographicSize = height / 2;
    }
}