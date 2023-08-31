using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindTheNumber
{
    public class NumberGenerator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private NumberBlock _numberBlockPrefab;
        private List<Vector2> points = new List<Vector2>();


        [Header("Properties")]
        private float _distanceEachPoint = 0.75f;


        [Header("Data")]
        private LevelData _levelData;


        private void Start()
        {
            LoadLevelData();
            int numOfPoints = _levelData.NumOfNumberBlocks;

            points = Utilities.GetRandomPointsInRectangleWithGrid(_levelData.TopLeft, _levelData.TopRight,
                                                                  _levelData.BotRight, _levelData.BotLeft,
                                                                  0.25f, _distanceEachPoint, numOfPoints, 1);

            if (points.Count == _levelData.NumOfNumberBlocks)
            {
                GenerateNumberBlocks(points);
            }
            else
            {
                points.Clear();
                points = _levelData.DefaultDifficultyData[Random.Range(0, _levelData.DefaultDifficultyData.Count)].Points;
                Shuffle(points);

                GenerateNumberBlocks(points);
            }          
        }


        private void LoadLevelData()
        {
            this._levelData = GameManager.Instance.PlayingLevelData;

            var mainCam = Camera.main;
            mainCam.orthographicSize = _levelData.OrthographicCameraSize;
            Vector3 newPosition = new Vector3(mainCam.transform.position.x + _levelData.CameraOffset.x, mainCam.transform.position.y + _levelData.CameraOffset.y, mainCam.transform.position.z);
            mainCam.transform.position = newPosition;
        }


        private void GenerateNumberBlocks(List<Vector2> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                NumberBlock numberBlock = Instantiate(_numberBlockPrefab, points[i], Quaternion.identity);
                numberBlock.SetNumber(i + 1);
            }
        }


        private void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

}
