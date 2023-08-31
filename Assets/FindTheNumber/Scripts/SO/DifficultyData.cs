using System.Collections.Generic;
using UnityEngine;

namespace FindTheNumber
{
    [CreateAssetMenu(fileName = "DifficultyData", menuName = "FindTheNumber/DifficultyData", order = 51)]
    public class DifficultyData : ScriptableObject
    {
        public List<Vector2> Points;
    }
}
