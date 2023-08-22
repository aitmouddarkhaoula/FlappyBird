using System;
using System.Collections;
using GameSystems;
using UnityEngine;

namespace GameSystems {
    public class UISystem : Singleton<UISystem> {
        [SerializeField] private GameObject _inGamePanel;
        [SerializeField] private GameObject _pausePanel;

        private bool _isInitialised;

        public void Awake() {
            GameStateSystem.OnGameStateChanged += UpdateUI;
            UpdateUI();
        }

        public void UpdateUI() {
            var currentState = GameStateSystem.GetState();

            switch (currentState) {
                case GameState.Playing:
                    SetActivePanel(inGamePanel_: true);
                    break;
                case GameState.Paused:
                    SetActivePanel(pausePanel_: true);
                    break;
            }
        }


        private void SetActivePanel(bool inGamePanel_ = false, bool pausePanel_ = false) {
            _inGamePanel.SetActive(inGamePanel_);
            _pausePanel.SetActive(pausePanel_);
        }



        public override void OnDestroy() {
            GameStateSystem.OnGameStateChanged -= UpdateUI;
            base.OnDestroy();
        }
    }
}