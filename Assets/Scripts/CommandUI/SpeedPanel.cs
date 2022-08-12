using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.CommandUI
{
    internal sealed class SpeedPanel : MainUI
    {
        [SerializeField] private Text _speed;

        public override void ShowPanel()
        {
            _speed.text = nameof(SpeedPanel);
            gameObject.SetActive(true);
        }

        public override void HidePanel()
        {
            gameObject.SetActive(false);
        }
    }
}
