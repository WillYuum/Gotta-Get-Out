using System;
using UnityEngine;
using UnityEngine.Events;

public class ColliderController : MonoBehaviour
{
    [HideInInspector] public UnityEvent<Collider> onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }

}
