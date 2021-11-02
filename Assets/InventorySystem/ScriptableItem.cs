using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScriptableItem", order = 1)]
public class ScriptableItem : ScriptableObject
{
    public string itemName;

    public Image icon;
}