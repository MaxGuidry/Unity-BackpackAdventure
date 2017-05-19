using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
using System;

public class ItemRemove : MonoBehaviour
{
    public Player p;
    public GameObject Prefab;
    //void Throw()
    //{
    //    var Kb = GetComponent<BackPackBehaviour>();
    //   var Ab = Instantiate(Resources.Load("GameItem/") as Item);
    //    Ab.RemoveItem(item);
    //    if (Kb.Items.Count <= 12)
    //        Kb.AddItem(Kb.Items[0]);


    //}
    void Start()
    {
        p.health = 100;
        p.mana = 100;
        Player.SavePlayer(p);
    }
    void Remove()
    {
        var nig = GetComponent<BackPackBehaviour>();
        if (nig.Items.Count > 0)
        {
            var datObject = Instantiate(Prefab);
            datObject.GetComponent<ItemBehaviour>().ItemConfig = nig.Items[0];
            datObject.transform.position = this.transform.position + (this.transform.forward * 3);
            if (nig.Items.Count > 0)
                nig.RemoveItem(nig.Items[0]);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            p =Player.LoadPlayer();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Player.SavePlayer(p);
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Remove();

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Throw();

        }
    }


}
