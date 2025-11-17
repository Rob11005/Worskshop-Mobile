using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buildings_Manager : MonoBehaviour
{
    public static Buildings_Manager Instance;
    public Transform buildingParent;
    public List<Bâtiment> allBuildings = new List<Bâtiment>();
    public BuildingPlacementSystemHex placementSystem;

    void Awake()
    {
        Instance = this;
    }

    public void PlaceBuilding(BuildingsData data)
    {
        //GameObject prefab = data.prefab;
        //GameObject buildingGO = Instantiate(prefab, Vector3.zero, Quaternion.identity, buildingParent);

        //Bâtiment batiment = buildingGO.GetComponent<Bâtiment>();
        //batiment.data = data;
        //batiment.b_level = 0;

        ShowingResources.Instance.UpdateResources();

        placementSystem.StartPlacement(data.prefab);
    }    

    public void RegisterBuilding(Bâtiment building)
    {
        allBuildings.Add(building);
    }

    public void UnregisterBuilding(Bâtiment building)
    {
        allBuildings.Remove(building);
    }
}
