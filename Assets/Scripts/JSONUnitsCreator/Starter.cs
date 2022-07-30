using UnityEngine;

namespace JsonUnits
{
    internal sealed class Starter : MonoBehaviour
    {
        private string _playerType;
        private int _playerHealth;

        private ICompositeUnitFactory _unitFactory;

        public void SetUnitFactory(ICompositeUnitFactory unitFactory)
        {
            _unitFactory = unitFactory;
        }
        
        private void Start()
        {
            IUnit player = _unitFactory.Create(_playerType, _playerHealth);
        }
    }
}
