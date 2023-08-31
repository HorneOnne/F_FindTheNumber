using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FindTheNumber
{
    public class UIHowToPlay : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _backBtn;


        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _backBtnText;
        [SerializeField] private TextMeshProUGUI _howToPlayContentText;





        private void OnEnable()
        {
            LanguageManager.OnLanguageChanged += LoadLanguague;
            LanguageManager.OnLanguageChanged += LoadHowToPlayContent;
        }

        private void OnDisable()
        {
            LanguageManager.OnLanguageChanged -= LoadLanguague;
            LanguageManager.OnLanguageChanged -= LoadHowToPlayContent;
        }

        private void Start()
        {
            LoadLanguague();
            LoadHowToPlayContent();

            _backBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayMainMenu(true);
            });
        }

        private void OnDestroy()
        {
            _backBtn.onClick.RemoveAllListeners();
        }



        private void LoadHowToPlayContent()
        {
            _howToPlayContentText.text = LanguageManager.Instance.GetHowToPlayContent(LanguageManager.Instance.CurrentLanguague);
        }

        private void LoadLanguague()
        {
            _backBtnText.text = LanguageManager.Instance.GetWord(LanguageManager.Instance.CurrentLanguague, "BACK");
        }
    }
}
