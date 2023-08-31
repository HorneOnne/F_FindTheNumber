﻿using UnityEngine;


namespace FindTheNumber
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance { get; private set; }
        public static event System.Action OnStateChanged;
        public static event System.Action OnPlaying;
        public static event System.Action OnWin;
        public static event System.Action OnGameOver;

        public enum GameState
        {
            WAITING,
            PLAYING,
            WIN,
            GAMEOVER,
            PAUSE,
            EXIT,
        }


        [Header("Properties")]
        [SerializeField] private GameState _currentState;
        [SerializeField] private float _waitTimeBeforePlaying = 0.5f;



        #region Properties
        public GameState CurrentState { get => _currentState; }
        #endregion


        #region Init & Events
        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            OnStateChanged += SwitchState;
        }

        private void OnDisable()
        {
            OnStateChanged -= SwitchState;
        }

        private void Start()
        {
            ChangeGameState(GameState.WAITING);
        }
        #endregion



        public void ChangeGameState(GameState state)
        {
            _currentState = state;
            OnStateChanged?.Invoke();
        }


        private void SwitchState()
        {
            switch (_currentState)
            {
                default: break;
                case GameState.WAITING:
                    StartCoroutine(Utilities.WaitAfter(_waitTimeBeforePlaying, () =>
                    {
                        ChangeGameState(GameState.PLAYING);
                    }));
                    break;
                case GameState.PLAYING:
                    Time.timeScale = 1.0f;

                    OnPlaying?.Invoke();
                    break;
                case GameState.WIN:
                    SoundManager.Instance.PlaySound(SoundType.Win, false);

                    StartCoroutine(Utilities.WaitAfter(1.0f, () =>
                    {
                        Loader.Load(Loader.Scene.MenuScene);
                    }));

                    OnWin?.Invoke();
                    break;
                case GameState.GAMEOVER:
         
                    OnGameOver?.Invoke();
                    break;
                case GameState.PAUSE:
                    Time.timeScale = 0.0f;
                    break;
                case GameState.EXIT:
                    Time.timeScale = 1.0f;
                    break;
            }
        }
    }
}

