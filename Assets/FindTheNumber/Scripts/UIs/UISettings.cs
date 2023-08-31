using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FindTheNumber
{
    public class UISettings : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private CustomGameButton _englishBtn;
        [SerializeField] private CustomGameButton _frenchBtn;
        [SerializeField] private CustomGameButton _italianBtn;
        [SerializeField] private Button _backBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _backBtnText;

        [Header("Colors")]
        [SerializeField] private Color _selectColor;
        [SerializeField] private Color _unselectColor;

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
            LoadLanguageUI();

            _englishBtn.Button.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                LanguageManager.Instance.ChangeLanguague(LanguageManager.Languague.English);
                LoadLanguageUI();
            });

            _frenchBtn.Button.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                LanguageManager.Instance.ChangeLanguague(LanguageManager.Languague.French);
                LoadLanguageUI();
            });


            _italianBtn.Button.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                LanguageManager.Instance.ChangeLanguague(LanguageManager.Languague.Italian);
                LoadLanguageUI();
            });

            _backBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayMainMenu(true);
            });
        }

        private void OnDestroy()
        {
            _englishBtn.Button.onClick.RemoveAllListeners();
            _frenchBtn.Button.onClick.RemoveAllListeners();
            _italianBtn.Button.onClick.RemoveAllListeners();
            _backBtn.onClick.RemoveAllListeners();
        }

        private void LoadLanguageUI()
        {
            switch (LanguageManager.Instance.CurrentLanguague)
            {
                case LanguageManager.Languague.English:
                    _englishBtn.SetButtonTextColor(_selectColor);
                    _frenchBtn.SetButtonTextColor(_unselectColor);
                    _italianBtn.SetButtonTextColor(_unselectColor);
                    break;
                case LanguageManager.Languague.French:
                    _englishBtn.SetButtonTextColor(_unselectColor);
                    _frenchBtn.SetButtonTextColor(_selectColor);
                    _italianBtn.SetButtonTextColor(_unselectColor);
                    break;
                case LanguageManager.Languague.Italian:
                    _englishBtn.SetButtonTextColor(_unselectColor);
                    _frenchBtn.SetButtonTextColor(_unselectColor);
                    _italianBtn.SetButtonTextColor(_selectColor);
                    break;
            }
        }

        private void LoadLanguague()
        {

            //switch (LanguageManager.Instance.CurrentLanguague)
            //{
            //    default:
            //    case LanguageManager.Languague.English:
            //        _playBtnText.fontSize = 70;
            //        _settingsBtnText.fontSize = 70;

            //        break;
            //    case LanguageManager.Languague.Norwegian:
            //    case LanguageManager.Languague.Italian:
            //    case LanguageManager.Languague.German:
            //        _playBtnText.fontSize = 55;
            //        _settingsBtnText.fontSize = 55;

            //        break;
            //}

            string englishString = LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "ENGLISH");
            string frenchString = LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "FRENCH");
            string italianString = LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "ITALIAN");

            _englishBtn.SetButtonText(englishString);
            _frenchBtn.SetButtonText(frenchString);
            _italianBtn.SetButtonText(italianString);
            _backBtnText.text = LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "BACK");
        }
    }
}
