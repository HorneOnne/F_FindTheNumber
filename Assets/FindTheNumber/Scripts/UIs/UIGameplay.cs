using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FindTheNumber
{
    public class UIGameplay : CustomCanvas
    {
        public static event System.Action OnSwitchBtnClicked;

        [Header("Buttons")]
        [SerializeField] private Button _backBtn;
        [SerializeField] private Button _switchBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private TextMeshProUGUI _moveText;



        private void Start()
        {

            //_backBtn.onClick.AddListener(() =>
            //{
            
            //});

            //_switchBtn.onClick.AddListener(() =>
            //{
           
            //});

        }

        private void OnDestroy()
        {
            //_backBtn.onClick.RemoveAllListeners();
            //_switchBtn.onClick.RemoveAllListeners();
        }   
    }
}
