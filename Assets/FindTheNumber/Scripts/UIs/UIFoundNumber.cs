using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FindTheNumber
{
    public class UIFoundNumber: CustomCanvas
    {
        [SerializeField] private Transform _root;
        [SerializeField] private Image _foundNumberImagePrefab;


        private void OnEnable()
        {
            GameLogicHandler.OnFoundNumberAt += CreateFoundNumberVisual;
        }

        private void OnDisable()
        {
            GameLogicHandler.OnFoundNumberAt -= CreateFoundNumberVisual;
        }


        private void CreateFoundNumberVisual(Vector2 position, Vector2 sizeDelta)
        {
            var found = Instantiate(_foundNumberImagePrefab, position, Quaternion.identity, _root.transform);
            found.rectTransform.sizeDelta = sizeDelta;
        }
    }
}
