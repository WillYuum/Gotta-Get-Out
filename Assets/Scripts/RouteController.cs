using UnityEngine;
using Utils;
using DG.Tweening;

public class RouteController : MonoBehaviour
{
    [SerializeField] private float moveDuration = 1.0f;
    [SerializeField] private PsuedoRandArray<Transform> positionToMoveTo;
    [SerializeField] private DelayController waitToMoveNextPoint;

    private Transform currentPointMovingTo;

    private bool isWaiting = false;
    void Awake()
    {
        if (positionToMoveTo.items.Length == 0)
        {
            enabled = false;
        }
        else
        {
            positionToMoveTo.ToggleShuffle(false);
            isWaiting = true;
            currentPointMovingTo = positionToMoveTo.PickNext();
        }
    }


    void Update()
    {
        if (isWaiting)
        {
            waitToMoveNextPoint.IncrementTimer(out bool isFinishedDelay);
            if (isFinishedDelay)
            {
                GoToNextPoint();
                waitToMoveNextPoint.ResetTimer();
            }
        }
    }

    private void GoToNextPoint()
    {
        isWaiting = false;

        Transform newPointToMoveTo = positionToMoveTo.PickNext();
        transform
        .DOMove(newPointToMoveTo.position, moveDuration)
        .SetEase(Ease.Linear)
        .OnComplete(OnReachedPoint);

        currentPointMovingTo = newPointToMoveTo;
    }

    private void OnReachedPoint()
    {
        isWaiting = true;
    }
}
