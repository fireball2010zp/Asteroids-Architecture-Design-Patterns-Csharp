using UnityEngine;

namespace Asteroids
{
    internal class Player : ViewPlayer
    {
        public void Start()
        {
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);

            _camera = Camera.main;

            var rotation = new RotationShip(transform);

            _ship = new Ship(moveTransform, rotation);

            _fireAction = new FireAction(_barrel, _force);
            _damageProcessing = new DamageProcessing(_hp);
        }


        public void Update()
        {
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);


            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _fireAction.Fire(_barrel);
            }  
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            _damageProcessing.Damage(_hp);
        }
    }
}

