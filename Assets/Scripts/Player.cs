using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Player", fileName = "Player", order = 0)]
public class Player : ScriptableObject
{
    public int health;
    public int mana;


    public static void SavePlayer(Player player)
    {
        var json = JsonUtility.ToJson(player);
        string path = Application.persistentDataPath;
        File.WriteAllText(path + "/player.json", json);
    }

    public static Player LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player.json";
        Player p = Resources.Load("Player") as Player;
        string json = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(json,p);
        if (!p)
            p = new Player();
        return p;
    }
}
