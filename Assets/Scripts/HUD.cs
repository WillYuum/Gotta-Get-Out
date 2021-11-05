using UnityEngine;
using Utils.GenericSingletons;

public class HUD : MonoBehaviourSingleton<HUD>
{
    [SerializeField] private GameObject winScreen;


    public void ToggleWinScreen(bool enable)
    {
        winScreen.SetActive(enable);
    }

}
