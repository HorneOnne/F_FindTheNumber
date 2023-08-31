using UnityEngine;
using System.Collections.Generic;

namespace FindTheNumber
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public static event System.Action OnScoreUp;

        // SCORE & BEST
        private int _score;
        private int _record;

        public enum Difficulty
        {
            LOW, MEDIUM, HARD
        }

        
        public List<LevelData> LevelData;
        public LevelData PlayingLevelData;


        #region Properties
        public Difficulty CurrentDifficulty { get; private set; }
        public int Score { get => _score; }
        public int Record { get => _record; }
        #endregion


        private void Awake()
        {
            // Check if an instance already exists, and destroy the duplicate
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            // FPS
            Application.targetFrameRate = 60;

            SetDifficult(Difficulty.LOW);
        }

        private void Start()
        {
            // Make the GameObject persist across scenes
            DontDestroyOnLoad(this.gameObject);
        }


        public void SetDifficult(Difficulty difficulty)
        {
            CurrentDifficulty = difficulty;

            switch(CurrentDifficulty)
            {
                case Difficulty.LOW:
                    PlayingLevelData = LevelData[0];
                    break;
                case Difficulty.MEDIUM:
                    PlayingLevelData = LevelData[1];
                    break;
                case Difficulty.HARD:
                    PlayingLevelData = LevelData[2];
                    break;
            }
        }
    }
}
