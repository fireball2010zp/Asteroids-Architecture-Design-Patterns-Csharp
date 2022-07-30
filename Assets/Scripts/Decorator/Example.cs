﻿using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class Example : MonoBehaviour
    {
        private IFire _fire;

        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")] 
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;

        [Header("Scope")]
        [SerializeField] private Transform _barrelPositionScope;
        [SerializeField] private GameObject _scope;

        public ModificationWeapon modificationWeapon;
        public Weapon weapon;

        public ModificationScope modificationScope;


        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            var weapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);

            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPosition, _muffler);
            ModificationWeapon modificationWeapon = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);

            var scope = new Scope(_barrelPositionScope, _scope);
            ModificationWeapon modificationScope = new ModificationScope(scope, _barrelPositionScope.position);

            modificationWeapon.ApplyModification(weapon);

            _fire = modificationWeapon;

            modificationScope.ApplyModification(weapon);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                modificationWeapon.CancelModification(weapon);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                modificationScope.CancelModification(weapon);
            }
        }
    }
}
