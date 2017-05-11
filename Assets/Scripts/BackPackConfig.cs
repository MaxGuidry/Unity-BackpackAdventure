﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="BackPackConfig",menuName ="BackPackConfig",order =1)]
public class BackPackConfig : ScriptableObject
{
    public List<ScriptableObjects.Item> items;
    public int capacity;
}
