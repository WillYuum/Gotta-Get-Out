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
            Transform playerTransform = Player.instance.transform;
            transform.forward = playerTransform.position - transform.position;

            if (Vector3.Distance(transform.position, playerTransform.position) < minDistToCatchPlayer)
            {
                GameLoopManager.instance.LoseGame();
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}
