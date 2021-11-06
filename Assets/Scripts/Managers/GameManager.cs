using UnityEngine;
using Utils.GenericSingletons;
using Tutorial;
using UnityEngine.SceneManagement;


public enum GameState { Paused, Playing, Tutorial };

public class GameManager : MonoBehaviourSingleton<GameManager>
{

    public GameState currentGameState { get; private set; }

    public bool hasPlayedTutorial = false;

    void Awake()
    {
        //FIXME: Should remove this!
        GameLoopManager.instance.StartGameLoop();

        hasPlayedTutorial = true;
        MapController.instance.onCreateNewPlatform += OnStartGame;
    }



    private void OnStartGame(Level level)
    {
        // GameIsOn = true;
        if (hasPlayedTutorial)
        {
            //Start a level
        }
        else
        {
            TutorialManager.instance.StartTutorial(level);
        }

        MapController.instance.onCreateNewPlatform -= OnStartGame;

        GameLoopManager.instance.StartGameLoop();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}

