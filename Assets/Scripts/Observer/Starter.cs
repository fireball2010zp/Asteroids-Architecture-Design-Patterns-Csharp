using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Observer
{
    public sealed class Starter : MonoBehaviour
    {
        [SerializeField] private View _view;
        [SerializeField] private Args _args;
        private List<IController> _controllers;

        private void Start()
        {
            var viewHp = new DamageProcessing(_args.ViewHp, true);
            _view.Inj(viewHp);

            _controllers = new List<IController>
            {
                new DestroyController(_view, viewHp)
            };
        }

        private void OnDestroy()
        {
            for (var index = 0; index < _controllers.Count; index++)
            {
                var controller = _controllers[index];
                controller.Dispose();
            }
            _controllers.Clear();
        }

    }
}


