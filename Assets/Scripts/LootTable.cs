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
            EditorGUILayout.TextField("Items Dropped",s);

            base.OnInspectorGUI();
        }
    }

}
