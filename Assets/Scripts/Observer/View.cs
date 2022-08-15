using System;
using UnityEngine;

namespace Asteroids.Observer
{
    internal sealed class View : MonoBehaviour
    {
        private Renderer _renderer;
        private DamageProcessing _viewExist;

        public event Action<Renderer> OnTriggerEnterChange;
        
        public void Inj(DamageProcessing viewExist)
        {
            _viewExist = viewExist;
            _viewExist.OnDestroyChange += OnDestroyChange;
            OnDestroyChange();
        }

        private void OnDestroyChange()
        {

            GUI.Box(new Rect(10, Screen.height / 2, 100, 100), new GUIContent(gameObject.ToString(), " is destroyed!"));
        }

        void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterChange?.Invoke(_renderer);
        }

        private void OnDestroy()
        {
            _viewExist.OnDestroyChange -= OnDestroyChange;
        }
    }
}

