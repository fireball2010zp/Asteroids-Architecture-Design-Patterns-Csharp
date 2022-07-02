using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;

        // ����� ���������� ������ AccelerationMove
        [SerializeField] private float _acceleration; 

        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;

        // �� �������� ����������� ������ � MoveTransform (������ � MoveTransform)
        //private Vector3 _move;

        // ����� �������� ����������� ������ � MoveTransform, ������ �� private IMove _moveTransform; 
        // private MoveTransform _moveTransform;

        // ������ private MoveTransform _moveTransform; ����� ���������� ������ AccelerationMove, ������ �� ���������� ������ Ship
        // private IMove _moveTransform;

        // ����� ���������� ������ RotationShip
        private Camera _camera;
        // ����� ���������� ������ RotationShip, ������ �� ���������� ������ Ship
        // private IRotation _rotation;

        // ����� ���������� ������ Ship
        private Ship _ship;


        private void Start()
        {
            // �������� ����� �������� ����������� ������ � MoveTransform � ������ �� ���������� ������ AccelerationMove
            // _moveTransform = new MoveTransform(transform, _speed);

            // �������� ����� ���������� ������ AccelerationMove, ����� ���������� ������ Ship ����� ����� (_moveTransform) �������� �� var moveTransform
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);

            // ����� ���������� ������ RotationShip
            _camera = Camera.main;

            // �������� ����� ���������� ������ RotationShip, ����� ���������� ������ Ship ����� ����� (_rotation) �������� �� var rotation
            var rotation = new RotationShip(transform);

            // ����� ���������� ������ Ship
            _ship = new Ship(moveTransform, rotation);
        }


        private void Update()
        {
            /* �� �������� ����������� ������ � MoveTransform
            var deltaTime = Time.deltaTime;
            var speed = deltaTime * _speed;
            _move.Set(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical")
            * speed, 0.0f);
            transform.localPosition += _move;
            */

            // �������� ����� �������� ����������� ������ � MoveTransform, ����� ���������� ������ ��������� _moveTransform.Move() �������� �� _ship.Move()
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            // ����� ���������� ������ RotationShip
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            // �������� ����� ���������� ������ RotationShip, ����� ���������� ������ Ship _rotation.Rotation(direction); �������� �� 
            _ship.Rotation(direction);


            // ����� ���������� ������ AccelerationMove
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                // ����� ���������� ������ Ship ������ ������� � ��������� �������� �� _ship.AddAcceleration();
                /*
                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.AddAcceleration();
                }
                */
                _ship.AddAcceleration();

            }

            // ����� ���������� ������ AccelerationMove
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                // ����� ���������� ������ Ship ������ ������� � ��������� �������� �� _ship.RemoveAcceleration();
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

