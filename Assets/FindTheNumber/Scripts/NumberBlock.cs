using UnityEngine;
using TMPro;

namespace FindTheNumber
{
    public class NumberBlock : MonoBehaviour
    {
        public static event System.Action<int, Vector2> OnNumberBlockClicked;
        [SerializeField] private TextMeshPro _numberText;

        public int Number { get;private set; }
        public bool IsFound { get; private set; } = false;


        public void SetNumber(int number)
        {
            IsFound = false;
            this.Number = number;
            _numberText.text = number.ToString();
        }


        private void OnMouseDown()
        {
            if(!IsFound)
            {
                OnNumberBlockClicked?.Invoke(Number, transform.position);
                if (GameLogicHandler.Instance.CheckFoundCondition(Number))
                {
                    IsFound = true;
                }
            }
           
        }
    }
}
