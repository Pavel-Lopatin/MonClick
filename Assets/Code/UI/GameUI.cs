using MonClick.Code.GameServices;
using System;
using UnityEngine;
using Zenject;

namespace MonClick.Code.UI
{
    public class GameUI : MonoBehaviour
    {
        [Inject] private GameController _gameController;

        [SerializeField] private GameObject _startGamePanel;
        [SerializeField] private GameObject _finishGamePanel;

        public event Action OnStartButtonClicked;

        [Inject]
        public void Init()
        {
            _gameController.OnPlayerBaseDestroyed += ShowDefeatInfo;
        }

        public void ShowStartGamePanel(bool state)
        {
            _startGamePanel.SetActive(state);
        }

        public void StartGameButton()
        {
            OnStartButtonClicked?.Invoke();
            ShowStartGamePanel(false);
        }

        public void ShowDefeatInfo()
        {
            _finishGamePanel.SetActive(true);
        }

        public void RestartGameButton()
        {
            OnStartButtonClicked?.Invoke();
            _finishGamePanel.SetActive(false);
        }
    }
}


