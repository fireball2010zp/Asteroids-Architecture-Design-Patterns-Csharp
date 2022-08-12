using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.CommandUI
{
    internal sealed class HandlerUI : MonoBehaviour
    {
        [SerializeField] private ScorePanel _scorePanel;
        [SerializeField] private HealthPanel _healthPanel;
        [SerializeField] private SpeedPanel _speedPanel;

        private readonly Stack<StatusUI> _status = new Stack<StatusUI>();
        
        private MainUI _window;

        private void Start()
        {
            _scorePanel.HidePanel();
            _healthPanel.HidePanel();
            _speedPanel.HidePanel();
        }

        private void ExecuteUI(StatusUI statusUI, bool isSave = true)
        {
            if (_window != null)
            {
                _window.HidePanel();
            }

            switch (statusUI)
            {
                case StatusUI.ScorePanel:
                    _window = _scorePanel;
                    break;

                case StatusUI.HealthPanel:
                    _window = _healthPanel;
                    break;

                case StatusUI.SpeedPanel:
                    _window = _speedPanel;
                    break;

                default:
                    break;
            }

            _window.ShowPanel();
            if (isSave)
            {
                _status.Push(statusUI);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ExecuteUI(StatusUI.ScorePanel);
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                ExecuteUI(StatusUI.HealthPanel);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                ExecuteUI(StatusUI.SpeedPanel);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_status.Count > 0)
                {
                    ExecuteUI(_status.Pop(), false);
                }
            }
        }
    }
}