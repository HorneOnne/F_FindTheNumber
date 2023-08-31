using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FindTheNumber
{
    public class UIDifficulty : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private CustomGameButton _lowBtn;
        [SerializeField] private CustomGameButton _mediumBtn;
        [SerializeField] private CustomGameButton _hardBtn;
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
            LoadDifficultUI();

            _lowBtn.Button.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                GameManager.Instance.SetDifficult(GameManager.Difficulty.LOW);
                LoadDifficultUI();
            });

            _mediumBtn.Button.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                GameManager.Instance.SetDifficult(GameManager.Difficulty.MEDIUM);
                LoadDifficultUI();
            });


            _hardBtn.Button.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                GameManager.Instance.SetDifficult(GameManager.Difficulty.HARD);
                LoadDifficultUI();
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
            _lowBtn.Button.onClick.RemoveAllListeners();
            _mediumBtn.Button.onClick.RemoveAllListeners();
            _hardBtn.Button.onClick.RemoveAllListeners();
            _backBtn.onClick.RemoveAllListeners();
        }

        private void LoadDifficultUI()
        {
            switch(GameManager.Instance.CurrentDifficulty)
            {
                case GameManager.Difficulty.LOW:
                    _lowBtn.SetButtonTextColor(_selectColor);
                    _mediumBtn.SetButtonTextColor(_unselectColor);
                    _hardBtn.SetButtonTextColor(_unselectColor);
                    break;
                case GameManager.Difficulty.MEDIUM:
                    _lowBtn.SetButtonTextColor(_unselectColor);
                    _mediumBtn.SetButtonTextColor(_selectColor);
                    _hardBtn.SetButtonTextColor(_unselectColor);
                    break;
                case GameManager.Difficulty.HARD:
                    _lowBtn.SetButtonTextColor(_unselectColor);
                    _mediumBtn.SetButtonTextColor(_unselectColor);
                    _hardBtn.SetButtonTextColor(_selectColor);
                    break;
            }
        }

        private void LoadLanguague()
        {
            _lowBtn.SetButtonText(LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "LOW"));
            _mediumBtn.SetButtonText(LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "MEDIUM"));
            _hardBtn.SetButtonText(LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "HARD"));       
               
            _backBtnText.text = LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "BACK");          
        }
    }
}
