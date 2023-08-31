using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FindTheNumber
{
    public class UIMenu : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _playBtn;
        [SerializeField] private CustomGameButton _difficultBtn;
        [SerializeField] private Button _settingsBtn;
        [SerializeField] private Button _howToPlayBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _playBtnText;
        [SerializeField] private TextMeshProUGUI _difficultBtnText;
        [SerializeField] private TextMeshProUGUI _settingsBtnText;
        [SerializeField] private TextMeshProUGUI _howToPlayBtnText;



        private void OnEnable()
        {
            LanguageManager.OnLanguageChanged += LoadLanguague;
        }

        private void OnDisable()
        {
            LanguageManager.OnLanguageChanged -= LoadLanguague;
        }

        private void Start()
        {
            LoadLanguague();

            _playBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                Loader.Load(Loader.Scene.GameplayScene);
            });

            _difficultBtn.Button.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayDifficultyMenu(true);
            });


            _settingsBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplaySettingsMenu(true);               
            });

            _howToPlayBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayHowToPlayMenu(true);
            });
        }

        private void OnDestroy()
        {
            _playBtn.onClick.RemoveAllListeners();
            _difficultBtn.Button.onClick.RemoveAllListeners();
            _settingsBtn.onClick.RemoveAllListeners();
            _howToPlayBtn.onClick.RemoveAllListeners();
        }



        private void LoadLanguague()
        {

            switch (LanguageManager.Instance.CurrentLanguague)
            {
                default:
                case LanguageManager.Languague.English:
                    _playBtnText.fontSize = 30;
                    _difficultBtn.ButtonText.fontSize = 30;
                    _settingsBtnText.fontSize = 30;
                    _howToPlayBtnText.fontSize = 24;
                    break;
                case LanguageManager.Languague.French:
                    _playBtnText.fontSize = 30;
                    _difficultBtn.ButtonText.fontSize = 30;
                    _settingsBtnText.fontSize = 24;
                    _howToPlayBtnText.fontSize = 20;
                    break;
                case LanguageManager.Languague.Italian:
                    _playBtnText.fontSize = 30;
                    _difficultBtn.ButtonText.fontSize = 30;
                    _settingsBtnText.fontSize = 24;
                    _howToPlayBtnText.fontSize = 24;
                    break;

            }


            _playBtnText.text = LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "PLAY");
            _difficultBtn.SetButtonText(LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "DIFFICULTY"));
            _settingsBtnText.text = LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "SETTINGS");
            _howToPlayBtnText.text = LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "HOW TO PLAY");
        }
    }
}
