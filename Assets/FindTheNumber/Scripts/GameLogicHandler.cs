using UnityEngine;

namespace FindTheNumber
{
    public class GameLogicHandler : MonoBehaviour
    {
        public static GameLogicHandler Instance { get; private set; }   
        public static event System.Action<Vector2, Vector2> OnFoundNumberAt;

        [Header("Data")]
        private LevelData _levelData;

        public int InitNumber{get; private set;}
        public int EndNumber { get; private set;}
        public int CurrentNeedFindNumber{get; private set;}




        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            NumberBlock.OnNumberBlockClicked += HandleGamelogicWhenClickNumberBlock;
        }

        private void OnDisable()
        {
            NumberBlock.OnNumberBlockClicked -= HandleGamelogicWhenClickNumberBlock;
        }

        private void Start()
        {
            _levelData = GameManager.Instance.PlayingLevelData;

            InitNumber = 1;
            EndNumber = _levelData.NumOfNumberBlocks;
            CurrentNeedFindNumber = InitNumber;
        }

        public void HandleGamelogicWhenClickNumberBlock(int number, Vector2 blockPosition)
        {
            if (CheckFoundCondition(number))
            {
                SoundManager.Instance.PlaySound(SoundType.HitBlock, false);
                OnFoundNumberAt?.Invoke(blockPosition, new Vector2(_levelData.UISizeDelta, _levelData.UISizeDelta));

                CurrentNeedFindNumber++;
                bool canWin = CheckWinCondition();
                if(canWin)
                {
                    GameplayManager.Instance.ChangeGameState(GameplayManager.GameState.WIN);
                }

            }
            else
            {
                SoundManager.Instance.PlaySound(SoundType.HitWall, false);
            }
        }

        public bool CheckFoundCondition(int number)
        {
            return number == CurrentNeedFindNumber;
        }

        public bool CheckWinCondition()
        {
            return CurrentNeedFindNumber > EndNumber;
        }
    }

}
