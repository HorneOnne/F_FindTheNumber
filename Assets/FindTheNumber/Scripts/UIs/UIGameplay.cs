using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FindTheNumber
{
    public class UIGameplay : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _backBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private TextMeshProUGUI _targetNumberText;


        // Cached
        private float _updateTimerFrequence = 0.5f;
        private float _updateTimerFrequenceCount = 0.0f;

        private void Start()
        {
            UpdateTargetNumberText();

            _backBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                Loader.Load(Loader.Scene.MenuScene);
            });
        }

      

        private void Update()
        {
            if (Time.time - _updateTimerFrequenceCount > _updateTimerFrequence)
            {
                _updateTimerFrequenceCount = Time.time;
                UpdateTimeUI();
                UpdateTargetNumberText();
            }
        }

        private void UpdateTimeUI()
        {
            _timeText.text = TimerManager.Instance.TimeToText();
        }

        private void UpdateTargetNumberText()
        {
            if(GameplayManager.Instance.CurrentState == GameplayManager.GameState.PLAYING)
                _targetNumberText.text = GameLogicHandler.Instance.CurrentNeedFindNumber.ToString();
            else if (GameplayManager.Instance.CurrentState == GameplayManager.GameState.WIN)
                    _targetNumberText.text = "-";
        }

        private void OnDestroy()
        {
            _backBtn.onClick.RemoveAllListeners();
        }
    }
}
