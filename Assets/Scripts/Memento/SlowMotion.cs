using UnityEngine;

namespace Memento
{
    public sealed class SlowMotion : MonoBehaviour
    {
        [SerializeField] private float _timeScale;
        private bool _isActive = true;

        private void OnCollisionEnter(Collision other)
        {
            if (_isActive)
            {
                // Time.timeScale = _timeScale;
                // Time.fixedDeltaTime = _timeScale * 0.05f;
            }
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 0.02f;
                _isActive = false;
            }
            if (Input.GetMouseButtonDown(1))
            {
                _isActive = true;
                Time.timeScale = _timeScale;
                Time.fixedDeltaTime = _timeScale * 0.05f;
            }
            if (Input.GetMouseButtonUp(1))
            {
                _isActive = false;
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 0.02f;
            }
        }
    }
}