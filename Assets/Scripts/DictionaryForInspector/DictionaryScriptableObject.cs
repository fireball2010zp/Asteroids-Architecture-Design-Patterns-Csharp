using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "New Dictionary Storage", menuName = "Data Objects/Dictionary Storage Object")]
    public class DictionaryScriptableObject : ScriptableObject
    {
        [SerializeField]
        private List<string> enemies = new List<string>();

        [SerializeField]
        private List<string> ammunition = new List<string>();

        public List<string> Enemies { get => enemies; set => enemies = value; }
        public List<string> Ammunition { get => ammunition; set => ammunition = value; }
    }
}


