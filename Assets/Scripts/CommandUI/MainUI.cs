using UnityEngine;

namespace Asteroids.CommandUI
{
    internal abstract class MainUI : MonoBehaviour
    {
        public abstract void ShowPanel();  

        public abstract void HidePanel();

    }
}
