using UnityEngine;

namespace FindTheNumber
{
    public class GameLogicHandler : MonoBehaviour
    {
        public static GameLogicHandler Instance { get; private set; }   
        public static event System.Action<Vector2, Vector2> OnFoundNumberAt;

        [Header("Data")]
        [SerializeField] private LevelData _levelData;

        [SerializeField] private int _initNumber;
        [SerializeField] private int _endNumber;
        [SerializeField] private int _currentNeedFindNumber;


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
            _initNumber = 1;
            _endNumber = _levelData.NumOfNumberBlocks;
            _currentNeedFindNumber = _initNumber;
        }

        public void HandleGamelogicWhenClickNumberBlock(int number, Vector2 blockPosition)
        {
            if (CheckFoundCondition(number))
            {
                Debug.Log($"TRUE:");
                OnFoundNumberAt?.Invoke(blockPosition, new Vector2(_levelData.UISizeDelta, _levelData.UISizeDelta));

                _currentNeedFindNumber++;
                bool canWin = CheckWinCondition();
                if(canWin)
                {
                    Debug.Log("WIN");
                }

            }
            else
            {
                Debug.Log("WRONG");
            }
        }

        public bool CheckFoundCondition(int number)
        {
            return number == _currentNeedFindNumber;
        }

        public bool CheckWinCondition()
        {
            return _currentNeedFindNumber > _endNumber;
        }
    }

}
