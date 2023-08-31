using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace FindTheNumber
{
    public class FoundSlot : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] float _shiftDuration = 1.0f;

        private void Start()
        {   
            StartCoroutine(ShiftValueOverTime(0f, 1f));
        }

        private IEnumerator ShiftValueOverTime(float startValue, float endValue)
        {
            float elapsedTime = 0;

            while (elapsedTime < _shiftDuration)
            {
                float currentValue = Mathf.Lerp(startValue, endValue, elapsedTime / _shiftDuration);
                _image.fillAmount = currentValue;

                elapsedTime += Time.deltaTime;
                yield return null; // Wait for the next frame
            }
            _image.fillAmount = endValue; // Ensure the final value is exact
        }
    }
}
