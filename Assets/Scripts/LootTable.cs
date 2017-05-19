using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "LootTable", menuName = "LootTable", order = 0)]
public class LootTable : ScriptableObject
{
    [System.Serializable]
    public class ItemDrop
    {
        public Item Item;
        [Range(0, 1)]
        public float ChanceToDrop;
    }

    public LootTable(List<Item> items)
    {

    }
    public List<ItemDrop> Drops;
    [SerializeField]
    private float randomRoll;
    public List<Item> GetDrops()
    {
        List<Item> drops = new List<Item>();
        randomRoll = Random.Range(0.0f, 1.0f);

        foreach (ItemDrop itemDrop in Drops)
        {
            if (randomRoll < itemDrop.ChanceToDrop)
                drops.Add(itemDrop.Item);
        }
        return drops;
    }
    [CustomEditor(typeof(LootTable))]
    public class InspectorLootTable : Editor
    {
        string s = "";
        public override void OnInspectorGUI()
        {
            string[] t = new[] { "test1", "Test2" };

            //I dont know how to change the selected button from the inspector by clicking/dont know how to access buttons
            GUILayout.SelectionGrid(0, t, 2);

            //adds empty space with whatever float of pixels is passed in
            GUILayout.Space(20f);

            //dont see a difference between TextArea and TextField
            GUILayout.TextArea("nig");
            GUILayout.TextField("nog");

            //almost the same as a SelectionGrid dont know how to change selected index they are buttons but I dont know how to access them.
            GUILayout.Toolbar(1, t);

            //idk how this even works
            //GUILayout.Window(1, new Rect(1, 1, 10, 10),new GUI.WindowFunction();

            //idk what the purpose of this one is
            EditorGUILayout.Vector2Field("Vector2Field test", new Vector2(2, 2));

            

            List<Item> items = new List<Item>();
            if (GUILayout.Button("Roll"))
            {

                s = "";
                var test = target as LootTable;
                var rngDrops = test.GetDrops();
                if (rngDrops == null)
                {

                }
                else
                {
                    items.AddRange(rngDrops);
                }

            }

            foreach (var item in items)
            {
                s += item.name + ", ";
            }
            EditorGUILayout.TextField("Items Dropped", s);

            base.OnInspectorGUI();
        }
    }

}
