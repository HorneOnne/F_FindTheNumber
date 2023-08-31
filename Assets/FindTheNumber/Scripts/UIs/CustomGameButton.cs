using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace FindTheNumber
{
    public class CustomGameButton : MonoBehaviour
    {             
        [SerializeField] private TextMeshProUGUI _btnText;
        [SerializeField] private TextMeshProUGUI _iconText;

        public Button Button { get; private set; }
        public TextMeshProUGUI ButtonText { get => _btnText; }
        public TextMeshProUGUI ButtonIconText { get => _iconText; }

        private void Awake()
        {
            Button = GetComponent<Button>();
        }

        public void SetButtonText(string text)
        {
            ButtonText.text = text;
            ButtonIconText.text = text[0].ToString();
        }

        public void SetButtonTextColor(Color color)
        {
            ButtonText.color = color;
            ButtonIconText.color = color;
        }
    }
}
