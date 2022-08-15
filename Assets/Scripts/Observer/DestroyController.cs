using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Observer
{
    internal sealed class DestroyController : IController
    {
        private readonly View _view;
        private readonly DamageProcessing _args;

        public DestroyController(View view, DamageProcessing args)
        {
            _view = view;
            _args = args;
            _view.OnTriggerEnterChange -= TriggerExistChange;
        }

        private void TriggerExistChange(Renderer obj)
        {
            _args.Exist = false;
        }

        public void Dispose()
        {
            _view.OnTriggerEnterChange -= TriggerExistChange;
        }
    }
}

