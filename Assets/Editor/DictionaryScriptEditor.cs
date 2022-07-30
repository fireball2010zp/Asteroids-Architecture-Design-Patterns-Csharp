using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Asteroids
{
    [CustomEditor(typeof(AsteroidsDictionary))]
    public class DictionaryScriptEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (((AsteroidsDictionary)target).modifyValues)
            {
                if (GUILayout.Button("Save changes"))
                {
                    ((AsteroidsDictionary)target).DeserializeDictionary();
                }
            }

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            if (GUILayout.Button("Print Dictionary"))
            {
                ((AsteroidsDictionary)target).PrintDictionary();
            }
        }
    }
}


