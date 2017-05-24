using System.Collections;
using System.Collections.Generic;
using System.IO;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;


public class BackPackBehaviour : MonoBehaviour
{

    public List<Item> Items;
    public int Capacity;
    public BackPackConfig Backpackconfig;
    private BackPack currentBackPack;
    [System.Serializable]
    public class OnBackPackChange : UnityEvent<BackPackBehaviour>
    {
    }

    public OnBackPackChange onBackPackChange;
    private void Start()
    {
        currentBackPack = new BackPack();
        Items = new List<Item>();
        if (!Backpackconfig)
        {
            foreach (var i in Backpackconfig.Items)
                AddItem(i);
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            this.transform.position += new Vector3(-0.1f, 0, 0);
        if (Input.GetKey(KeyCode.W))
            this.transform.position += new Vector3(0, 0, .1f);
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0, 0, -.1f);
        if (Input.GetKey(KeyCode.D))
            this.transform.position += new Vector3(.1f, 0, 0);
    }

    void UpdateCurrentBackPack()
    {
        currentBackPack.backpackItems = Items;
    }
    public class OnSave : UnityEvent<BackPack, string>
    { }

    public void Load()
    {
        currentBackPack = LoadBackPack("BackPack");
        Items = currentBackPack.backpackItems;
        onBackPackChange.Invoke(this);
    }
    public void Save()
    {
        SaveBackPack(currentBackPack, "BackPack");
    }
    private OnSave onSave = new OnSave();
    private void SaveBackPack(BackPack bp, string fileName)
    {
        BackPack backpack = ScriptableObject.CreateInstance<BackPack>();
        backpack.backpackItems = bp.backpackItems;
        var json = JsonUtility.ToJson(backpack, true);
        List<Item> lItems = new List<Item>();

        string path = Application.persistentDataPath;
        if (!File.Exists(path))
        {
            Directory.CreateDirectory(path + "/Saves");
        }
        File.WriteAllText(path + "/Saves/" + fileName + ".json", json);
    }

    private BackPack LoadBackPack(string fileName)
    {
        string path = Application.persistentDataPath;
        var json = File.ReadAllText(path + "/Saves/" + fileName + ".json");
        BackPack bp = ScriptableObject.CreateInstance<BackPack>();
        JsonUtility.FromJsonOverwrite(json, bp);
        if (!bp)
            bp = ScriptableObject.CreateInstance<BackPack>();
        return bp;
    }

    public void LoadBackPackIn(BackPackConfig newBackpack)
    {
        List<Item> oldItems = new List<Item>();
        oldItems.AddRange(Items);
        Items.Clear();
        foreach (var variable in newBackpack.Items)
            AddItem(variable);
        foreach (var variable in oldItems)
            AddItem(variable);
    }

    public void AddItem(Item item)
    {
        if (Items.Count < Capacity)
        {
            Items.Add(item);
            onBackPackChange.Invoke(this);
            UpdateCurrentBackPack();

        }
    }

    public void RemoveItem(Item item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item);
            onBackPackChange.Invoke(this);
            UpdateCurrentBackPack();

        }
    }
}
