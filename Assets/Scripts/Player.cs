using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;

        // appeared after adding the class AccelerationMove
        [SerializeField] private float _acceleration; 

        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;

        // existed before moving the Player's movement functionality to MoveTransform (now in the MoveTransform class)
        // private Vector3 _move;

        // appeared after moving the Player's movement functionality to MoveTransform, replaced by "private IMove _moveTransform;"
        // private MoveTransform _moveTransform;

        // appeared instead of "private MoveTransform _moveTransform;" after addition of the AccelerationMove class, lasted until the addition of the Ship class
        // private IMove _moveTransform;

        // appeared after adding the class RotationShip
        private Camera _camera;
        // appeared after adding the RotationShip class, lasted until the addition of the Ship class
        // private IRotation _rotation;

        // appeared after adding the Ship class
        private Ship _ship;


        private void Start()
        {
            // appeared after moving the Player's movement functionality to MoveTransform, lasted until the addition of the AccelerationMove class
            // _moveTransform = new MoveTransform(transform, _speed);

            // appeared after adding the AccelerationMove class, after adding the Ship class left part "_moveTransform" changed to "var moveTransform"
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);

            // appeared after adding the RotationShip class
            _camera = Camera.main;

            // appeared after adding the RotationShip class, after adding the Ship class left part "_rotation" changed to "var rotation"
            var rotation = new RotationShip(transform);

            // appeared after adding the Ship class
            _ship = new Ship(moveTransform, rotation);
        }


        private void Update()
        {
            /* existed before moving the Player's movement functionality to MoveTransform (now in the MoveTransform class)
            
            var deltaTime = Time.deltaTime;
            var speed = deltaTime * _speed;
            _move.Set(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical")
            * speed, 0.0f);
            transform.localPosition += _move;
            */

            // appeared after moving the Player's movement functionality to MoveTransform, after adding the Ship class part "_moveTransform.Move()" changed to "_ship.Move()"
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            // appeared after adding the RotationShip class
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            // appeared after adding the RotationShip class, after adding the Ship class string "_rotation.Rotation(direction);" changed to
            _ship.Rotation(direction);


            // appeared after adding the AccelerationMove class
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                // after adding the Ship class, condition with the action was changed to "_ship.AddAcceleration();"
                /*
                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.AddAcceleration();
                }
                */
                _ship.AddAcceleration();

            }

            // appeared after adding the AccelerationMove class
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                // after adding the Ship class, condition with the action was changed to "_ship.RemoveAcceleration();"
                /*
                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.RemoveAcceleration();
                }
                */
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _force);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}

