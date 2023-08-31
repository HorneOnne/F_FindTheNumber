using System.Collections.Generic;
using UnityEngine;

namespace FindTheNumber
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "FindTheNumber/LevelData", order = 51)]
    public class LevelData : ScriptableObject
    {
        [Header("Camera zoom")]
        public float OrthographicCameraSize = 5;
        public Vector2 CameraOffset;

        [Space(10)]
        public Vector2 TopLeft;
        public Vector2 TopRight;
        public Vector2 BotRight;
        public Vector2 BotLeft;

        [Space(10)]
        public int NumOfNumberBlocks;
        public float UISizeDelta;
        public List<DifficultyData> DefaultDifficultyData;
    }
}
