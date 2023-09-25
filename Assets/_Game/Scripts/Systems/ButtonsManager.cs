using System.Collections;
using System.Collections.Generic;
using GameSystems;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Button _nextLevel;
    private void Start()
    {
        _startGameButton.onClick.AddListener(StartGame);
        _restartGameButton.onClick.AddListener(RestartGame);
        _nextLevel.onClick.AddListener(NextLevel);
    }

    private void NextLevel()
    {
        
    }

    private void RestartGame()
    {
        GameStateSystem.SetState(GameState.StartingMenu);
        GameManager.Instance.Reset();
    }

    public void StartGame()
    {
        GameStateSystem.SetState(GameState.Playing);
       
    }

   
}
