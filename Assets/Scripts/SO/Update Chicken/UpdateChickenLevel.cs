using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

[Serializable]
public class UpdateChickenLevel 
{
    [Header("Chicken Name")]
    public string name;

    [Header("Gold Update")]
    public float gold;
}