using UnityEngine;


namespace Chaser
{
    public class Chaser : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 7.5f;
        [SerializeField] private FOW fow;
        private bool isTryingToCatchPlayer = false;


        private float minDistToCatchPlayer = 0.25f;

        void Awake()
        {
            fow.EnableFOW();
            fow.onCaughtTarget += InvokeSawPlayer;
        }

        void Update()
        {
            if (GameLoopManager.instance.GameIsOn == false) return;

            if (isTryingToCatchPlayer)
            {
                HandleCatchPlayer();
            }
        }


        private void InvokeSawPlayer()
        {
            fow.DisableFOW();
            fow.onCaughtTarget -= InvokeSawPlayer;
            isTryingToCatchPlayer = true;
        }

        private void HandleCatchPlayer()
        {
            print("Moving towards player");
            Transform targetTransform = Player.instance.transform;

            RotateTowardTarget(targetTransform.position);

            if (Vector3.Distance(transform.position, targetTransform.position) < minDistToCatchPlayer)
            {
                GameLoopManager.instance.LoseGame();
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);
            }
        }

        private void RotateTowardTarget(Vector3 target)
        {
            target = new Vector3(target.x, transform.position.y, target.z);
            transform.LookAt(target);
        }
    }
}
