using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Window : ScriptableObject
{

    public class LootTableWindow : EditorWindow
    {

        private GUIStyle Header = new GUIStyle();
        public List<LootTable> Tables = new List<LootTable>();
        private static string path;
        [MenuItem("Tools/LootTableWindow")]
        static void Init()
        {
            var window = EditorWindow.GetWindow(typeof(LootTableWindow));
            window.Show();
            path = Application.dataPath;
        }
        private void OnGUI()
        {
            Header.alignment = TextAnchor.UpperCenter;
            Header.fontStyle = FontStyle.BoldAndItalic;
            Header.fontSize = 40;
            Header.normal.textColor = Color.cyan;
            GUILayout.Label("You Shouldn't be here...",Header);
            GUILayout.Space(25);
            if (GUILayout.Button("This is a button"))
            {
               // Tables.AddRange(AssetDatabase.LoadAllAssetsAtPath(Application.dataPath + "/Scripts/Infantry Loot").ToList<LootTable>());
                foreach (var v in Tables)
                {
                    GUILayout.Label(v.Drops.ToString(), Header);
                }
            }
           
           

        }


    }
}