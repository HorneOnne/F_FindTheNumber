﻿using UnityEngine;

namespace FindTheNumber
{
    public class UIGameplayManager : MonoBehaviour
    {
        public static UIGameplayManager Instance { get; private set; }

        public UIGameplay UIGameplay;
     


        private void Awake()
        {
            Instance = this;
        }


        private void Start()
        {
            CloseAll();
            DisplayGameplayMenu(true);
        }

        public void CloseAll()
        {
            DisplayGameplayMenu(false);
            DisplayPauseMenu(false);
            DisplayGameoverMenu(false);     
        }


        public void DisplayGameplayMenu(bool isActive)
        {
            UIGameplay.DisplayCanvas(isActive);
        }

        public void DisplayPauseMenu(bool isActive)
        {
            //UIPause.DisplayCanvas(isActive);
        }

        public void DisplayGameoverMenu(bool isActive)
        {
            //UIGameover.DisplayCanvas(isActive);
        }
    }
}
