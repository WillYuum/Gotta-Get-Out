using UnityEngine;
using Utils.GenericSingletons;
using Tutorial;
using UnityEngine.SceneManagement;

public class GameLoopManager : MonoBehaviourSingleton<GameLoopManager>
{
    [SerializeField] private bool _gameIsOn;
    public bool GameIsOn
    {
        get
        {
            return _gameIsOn;
        }
        private set
        {
            _gameIsOn = value;
        }
    }



    public void StartGameLoop()
    {
        print("Game loop started");

        GameIsOn = true;
    }

    public void HandlePlayerOnReachEndOfPlatform()
    {
        Debug.Log("Switching to new platform");

        if (TutorialManager.instance.tutorialIsActive)
        {
            MapController.instance.SpawnDefaultLevel();
        }
        else
        {
            MapController.instance.SpawnAnotherLevel();
        }

        Vector2 nextCameraPos = MapController.instance.GetLatestSpawnedPlatformPos();
        CameraController.instance.MoveCameraToNextPlatform(nextCameraPos);

        Player.instance.MoveToNextPlatform();
    }


    public void WinGame()
    {
        print("Won game");

        HUD.instance.ToggleWinScreen(true);
        Invoke(nameof(Restart), 2.5f);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseGame()
    {
        GameIsOn = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
