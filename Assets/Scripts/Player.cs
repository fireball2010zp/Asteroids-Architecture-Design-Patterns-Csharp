using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;

        // после добавления класса AccelerationMove
        [SerializeField] private float _acceleration; 

        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;

        // до переноса перемещения игрока в MoveTransform (теперь в MoveTransform)
        //private Vector3 _move;

        // после переноса перемещения игрока в MoveTransform, замена на private IMove _moveTransform; 
        // private MoveTransform _moveTransform;

        // вместо private MoveTransform _moveTransform; после добавления класса AccelerationMove, прожил до добавления класса Ship
        // private IMove _moveTransform;

        // после добавления класса RotationShip
        private Camera _camera;
        // после добавления класса RotationShip, прожил до добавления класса Ship
        // private IRotation _rotation;

        // после добавления класса Ship
        private Ship _ship;


        private void Start()
        {
            // появился после переноса перемещения игрока в MoveTransform и прожил до добавления класса AccelerationMove
            // _moveTransform = new MoveTransform(transform, _speed);

            // появился после добавления класса AccelerationMove, после добавления класса Ship левую часть (_moveTransform) изменили на var moveTransform
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);

            // после добавления класса RotationShip
            _camera = Camera.main;

            // появился после добавления класса RotationShip, после добавления класса Ship левую часть (_rotation) изменили на var rotation
            var rotation = new RotationShip(transform);

            // после добавления класса Ship
            _ship = new Ship(moveTransform, rotation);
        }


        private void Update()
        {
            /* до переноса перемещения игрока в MoveTransform
            var deltaTime = Time.deltaTime;
            var speed = deltaTime * _speed;
            _move.Set(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical")
            * speed, 0.0f);
            transform.localPosition += _move;
            */

            // появился после переноса перемещения игрока в MoveTransform, после добавления класса обращение _moveTransform.Move() заменили на _ship.Move()
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            // после добавления класса RotationShip
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            // появился после добавления класса RotationShip, после добавления класса Ship _rotation.Rotation(direction); заменили на 
            _ship.Rotation(direction);


            // после добавления класса AccelerationMove
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                // после добавления класса Ship данное условие с действием изменили на _ship.AddAcceleration();
                /*
                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.AddAcceleration();
                }
                */
                _ship.AddAcceleration();

            }

            // после добавления класса AccelerationMove
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                // после добавления класса Ship данное условие с действием изменили на _ship.RemoveAcceleration();
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

