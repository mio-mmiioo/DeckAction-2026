using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDataBase", menuName = "Scriptable Objects/CardDataBase")]
public class CardDataBase : ScriptableObject
{
    public List<CardData> CardData=new List<CardData>();
}




