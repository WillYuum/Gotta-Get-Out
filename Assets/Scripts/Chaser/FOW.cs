using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chaser
{
    public class FOW : MonoBehaviour
    {

        private bool fowIsActive = false;

        [SerializeField] public float viewRadius;
        [Range(0, 360)]
        [SerializeField] public float viewAngle;

        [SerializeField] private FowVisual fowVision;
        public event Action onCaughtTarget;


        [Header("Filters")]
        [SerializeField] private LayerMask targetMask;
        [SerializeField] private LayerMask obstacleMask;
        [SerializeField] private float delayToFindTarget = .2f;



        [HideInInspector]
        public List<Transform> visibleTargets;

        private Transform target;
        void Awake()
        {
            target = transform.parent;
            visibleTargets = new List<Transform>();
        }

        void Update()
        {
            fowVision.SetOrigin(target.position);

            Vector3 forwardDir = (target.position + Vector3.forward) - target.position;
            fowVision.SetAimDirection(forwardDir.normalized);
        }


        public void EnableFOW()
        {
            gameObject.SetActive(true);
            fowIsActive = true;
            StartCoroutine(nameof(FindTargetsWithDelay), delayToFindTarget);
        }

        public void DisableFOW()
        {
            gameObject.SetActive(false);
            fowIsActive = false;
            StopCoroutine(nameof(FindTargetsWithDelay));
        }



        IEnumerator FindTargetsWithDelay(float delay)
        {
            while (fowIsActive)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleTargets();
            }
        }

        private void FindVisibleTargets()
        {
            visibleTargets.Clear();
            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask.value);


            bool caughtTarget = false;

            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.position);

                    bool isTargetVisible = !Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask);

                    if (isTargetVisible)
                    {
                        visibleTargets.Add(target);
                        caughtTarget = true;
                        break;
                    }
                }
            }

            if (caughtTarget)
            {
                onCaughtTarget?.Invoke();
            }
        }


        public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal = false)
        {
            if (!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
    }
}
