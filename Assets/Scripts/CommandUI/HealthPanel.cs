using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.CommandUI
{
    internal sealed class HealthPanel : MainUI
    {
        [SerializeField] private Text _health;
        
        public override void ShowPanel()
        {
            _health.text = nameof(HealthPanel);
            gameObject.SetActive(true);
        }

        public override void HidePanel()
        {
            gameObject.SetActive(false);
        }
    }
}
