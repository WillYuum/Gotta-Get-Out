using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideableObj : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player.instance.gameObject)
        {
            HandlePlayerEnterHide();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == Player.instance.gameObject)
        {
            HandlePlayerExitHide();
        }
    }


    private void HandlePlayerEnterHide()
    {
        Player.instance.EnterHideState();
    }

    private void HandlePlayerExitHide()
    {
        Player.instance.ExitHideState();
    }

}
