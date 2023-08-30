using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindTheNumber
{
    public class NumberGenerator : MonoBehaviour
    {
        [Header("Points")]
        [SerializeField] private Transform _topLeft;
        [SerializeField] private Transform _topRight;
        [SerializeField] private Transform _botLeft;
        [SerializeField] private Transform _botRight;

        [SerializeField] private List<Vector2> points = new List<Vector2>();

        private void Start()
        {
            points = Utilities.GetRandomPointsInRectangle(_topLeft.position, _topRight.position, 
                                                              _botRight.position, _botLeft.position, 
                                                              0f, 0.2f, 60);


        }
    }

}
