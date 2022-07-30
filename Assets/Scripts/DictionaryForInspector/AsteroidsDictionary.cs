using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
	public class AsteroidsDictionary : MonoBehaviour, ISerializationCallbackReceiver
	{
		[SerializeField]
		private DictionaryScriptableObject dictionaryData;

        public bool modifyValues;

        [SerializeField]
		private List<string> enemies = new List<string>();

		[SerializeField]
		private List<string> ammunition = new List<string>();

        private Dictionary<string, string> myDictionary = new Dictionary<string, string>();


        public void Awake()
        {
            for (int i = 0; i < Mathf.Min(dictionaryData.Enemies.Count, dictionaryData.Ammunition.Count); i++)
            {
                myDictionary.Add(dictionaryData.Enemies[i], dictionaryData.Ammunition[i]);
            }
        }

        public void OnAfterDeserialize()
        {
            if (modifyValues == false)
            {
                enemies.Clear();
                ammunition.Clear();
                for (int i = 0; i < Mathf.Min(dictionaryData.Enemies.Count, dictionaryData.Ammunition.Count); i++)
                {
                    enemies.Add(dictionaryData.Enemies[i]);
                    ammunition.Add(dictionaryData.Ammunition[i]);
                }
            }
        }

        public void OnBeforeSerialize()
        {
            
        }

        public void DeserializeDictionary()
        {
            Debug.Log("DESERIALIZATION");
            myDictionary = new Dictionary<string, string>();
            dictionaryData.Enemies.Clear();
            dictionaryData.Ammunition.Clear();


            for (int i = 0; i < Mathf.Min(enemies.Count, ammunition.Count); i++)
            {
                dictionaryData.Enemies.Add(enemies[i]);
                dictionaryData.Ammunition.Add(ammunition[i]);

                myDictionary.Add(enemies[i], ammunition[i]);
            }
            modifyValues = false;
        }

        public void PrintDictionary()
        {
            foreach (var pair in myDictionary)
            {
                Debug.Log("Enemy: " + pair.Key + " Ammunition: " + pair.Value);
            }
        }
    }
}


