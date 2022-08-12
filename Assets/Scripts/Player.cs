using UnityEngine;

namespace Asteroids
{
    internal class Player
    {
        public ViewPlayer camera;
        public ViewPlayer ship;
        public ViewPlayer transform;
        public ViewPlayer speed;
        public ViewPlayer acceleration;
        public ViewPlayer barrel;
        public ViewPlayer force;
        public ViewPlayer hp;

        public ViewPlayer fireAction;
        public ViewPlayer damage;

        public void Start()
        {
            var moveTransform = new AccelerationMove(transform.transform, speed._speed, acceleration._acceleration);

            camera._camera = Camera.main;

            var rotation = new RotationShip(transform.transform);

            ship._ship = new Ship(moveTransform, rotation);

            fireAction._fireAction = new FireAction(barrel._barrel, force._force);
            damage._damageProcessing = new DamageProcessing(hp._hp);
        }


        public void Update()
        {
            ship._ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            var direction = Input.mousePosition - camera._camera.WorldToScreenPoint(transform.transform.position);
            ship._ship.Rotation(direction);


            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ship._ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                ship._ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                fireAction._fireAction.Fire(barrel._barrel);
            }  
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            damage._damageProcessing.Damage(hp._hp);
        }
    }
}

