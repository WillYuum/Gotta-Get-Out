using System;
using UnityEngine;
using UnityEngine.Events;

public class ColliderController : MonoBehaviour
{
    [HideInInspector] public UnityEvent<Collider2D> onTriggerEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnter.Invoke(other);
    }

}
