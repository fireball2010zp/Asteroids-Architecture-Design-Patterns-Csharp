using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class EnemyBridge
    {
        private IWeapon _attack;
        private IMoveEnemy _move;
        public EnemyBridge(IWeapon attack, IMoveEnemy move)
        {
            _attack = attack;
            _move = move;
        }
        public void Fire()
        {
            _attack.Fire();
        }
        public void Move()
        {
            _move.Move();
        }
        public void Switch(IMoveEnemy move)
        {
            _move = move;
        }
    }
}
