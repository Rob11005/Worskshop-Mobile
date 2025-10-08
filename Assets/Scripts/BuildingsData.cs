using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(menuName = "BuildingData")]
public class BuildingsData : ScriptableObject
{
    public string buildingName;
    public Sprite buildingIcon;
    public GameObject prefab;

    [System.Serializable]
    public class LevelInfo
    {
        public List<ResourceAmount> cost;
        public List<ResourceAmount> production;
    }

    public List<LevelInfo> levels;


}
[System.Serializable]
    public class ResourceAmount
    {
        public string resourceName;
        public int amount;
    }