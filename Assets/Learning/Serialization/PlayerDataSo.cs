using System;
using UnityEditor;
using UnityEngine;

namespace Serialization.Save {
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Serialization/PlayerData")]
    public class PlayerDataSo : ScriptableObject {
        public PlayerData playerData;
    }

#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(PlayerDataSo))]
    public class PlayerDataSoCustomEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();
            PlayerDataSo playerDataSo = (PlayerDataSo)target;
            if(GUILayout.Button("Save")) {
                SaveSystem.Save(playerDataSo.playerData);
            }
            if(GUILayout.Button("Load")) {
                try {
                    playerDataSo.playerData = SaveSystem.Load<PlayerData>();
                }
                catch(Exception e) {
                    Debug.Log(e);
                    playerDataSo.playerData = new PlayerData();
                }

                EnemyData enemyData = SaveSystem.Load<EnemyData>();
            }
            if(GUILayout.Button("Save SO asset only")) {
                AssetDatabase.SaveAssets();
            }
        }
    }
#endif
}
