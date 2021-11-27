using UnityEngine;
using Utils.GenericSingletons;

namespace Tutorial
{


    public class TutorialManager : MonoBehaviourSingleton<TutorialManager>
    {

        [SerializeField] private GameObject[] tutorialNodes;

        [HideInInspector] public bool tutorialIsActive { get; private set; }


        private int tutorialNodeIndex = 0;

        void Awake()
        {
            tutorialNodeIndex = 0;
            DisableAllTutorialNodes();
        }


        public void StartTutorial(Level level)
        {
            tutorialIsActive = true;

            MapController.instance.onCreateNewPlatform += OnJumpToNewLevel;
            SetTutorialOnLevel(level);
            DisplayTutorialNode();
        }


        private void DisplayTutorialNode()
        {
            Debug.Log("Display tutorial number: " + tutorialNodeIndex);
            tutorialNodes[tutorialNodeIndex].SetActive(true);

            tutorialNodeIndex += 1;

            if (tutorialNodeIndex > tutorialNodes.Length - 1)
            {
                EndTutorialMode();
            }
        }

        private void OnJumpToNewLevel(Level level)
        {
            SetTutorialOnLevel(level);
            DisplayTutorialNode();
        }

        private void SetTutorialOnLevel(Level level)
        {
            Vector3 tutorialYPos = tutorialNodes[tutorialNodeIndex].transform.position;

            //Ypos is adjusted in scene
            tutorialYPos.x = level.transform.position.x;
            tutorialYPos.z = level.transform.position.z;
            tutorialNodes[tutorialNodeIndex].transform.position = tutorialYPos;
        }

        private void EndTutorialMode()
        {
            Debug.Log("Ended Tutorial");
            tutorialIsActive = false;
            MapController.instance.onCreateNewPlatform -= OnJumpToNewLevel;
        }



        private void DisableAllTutorialNodes()
        {
            foreach (var item in tutorialNodes)
            {
                item.SetActive(false);
            }
        }
    }
}