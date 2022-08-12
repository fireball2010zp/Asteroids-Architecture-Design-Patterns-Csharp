using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memento
{
    public class RewindController
    {
        private Transform _transform;
        private List<PointInTime> _pointsInTime;
        public bool _isRewinding;
        private Rigidbody _rb;

        public void Rewind()
        {
            _pointsInTime = new List<PointInTime>();
            
            if (_pointsInTime.Count > 1)
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }

        public void StartRewind()
        {
            _isRewinding = true;
            _rb.isKinematic = true;
        }

        public void StopRewind()
        {
            _isRewinding = false;
            _rb.isKinematic = false;
            _rb.velocity = _pointsInTime[0].Velocity;
            _rb.angularVelocity = _pointsInTime[0].AngularVelocity;
        }
        
    }
}