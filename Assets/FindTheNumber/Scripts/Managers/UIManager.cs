using UnityEngine;

namespace FindTheNumber
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        public UIMenu UIMenu;
        public UIDifficulty UIDifficulty;
        public UISettings UISettings;
        public UIHowToPlay UIHowToPlay;
    


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            CloseAll();
            DisplayMainMenu(true);
        }

        public void CloseAll()
        {
            DisplayMainMenu(false);
            DisplayDifficultyMenu(false);
            DisplaySettingsMenu(false);
            DisplayHowToPlayMenu(false);
        }

        public void DisplayMainMenu(bool isActive)
        {
            UIMenu.DisplayCanvas(isActive);
        }


        public void DisplayDifficultyMenu(bool isActive)
        {
            UIDifficulty.DisplayCanvas(isActive);
        }


        public void DisplaySettingsMenu(bool isActive)
        {
            UISettings.DisplayCanvas(isActive);
        }

        public void DisplayHowToPlayMenu(bool isActive)
        {
            UIHowToPlay.DisplayCanvas(isActive);
        }
    }
}
