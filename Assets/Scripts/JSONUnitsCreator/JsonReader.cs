using System.IO;
using UnityEngine;

namespace JsonUnits
{
    public class JsonReader : MonoBehaviour
    {
        public UnitJson unitJson;

        private void Start()
        {
            LoadData();
        }

        public void LoadData()
        {
            unitJson = JsonUtility.FromJson<UnitJson>(File.ReadAllText(Application.streamingAssetsPath + "json.txt"));
        }

        [System.Serializable]
        public class UnitJson
        {
            public string type;
            public int health;
        }

    }
}