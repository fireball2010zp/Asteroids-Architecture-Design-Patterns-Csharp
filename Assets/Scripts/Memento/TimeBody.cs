using System.Collections.Generic;
using UnityEngine;


namespace Memento
{
    public sealed class TimeBody : MonoBehaviour 
    {
        [SerializeField] private float _recordTime = 5f;
        private List<PointInTime> _pointsInTime;
        private Rigidbody _rb;

        RewindController rewinding = new RewindController();

        private void Start ()
        {
            _pointsInTime = new List<PointInTime>();
            _rb = GetComponent<Rigidbody>();
            if (Random.Range(0, 100) > 50)
            {
                var colorHSV = Random.ColorHSV();
                var light = new GameObject();
                light.transform.SetParent(transform);
                var addComponent = light.AddComponent<Light>();
                addComponent.color = colorHSV;
                addComponent.shadows = LightShadows.Soft;
                GetComponent<Renderer>().material.color = colorHSV;
            }
        }

        private void Update ()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                rewinding.StartRewind();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                rewinding.StopRewind();
            }
        }
        
        private void FixedUpdate ()
        {
            if (rewinding._isRewinding)
            {
                rewinding.Rewind();
            }
            else
            {
                Record();
            }
        }

        private void Record ()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }
            _pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation, _rb.velocity, _rb.angularVelocity));
        }
    }
}
