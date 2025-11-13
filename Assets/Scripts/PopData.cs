using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
[CreateAssetMenu(menuName = "PopData")]
public class PopData : ScriptableObject
{
    public string popName;
    public Image PopSprite;
    public string description;
}
