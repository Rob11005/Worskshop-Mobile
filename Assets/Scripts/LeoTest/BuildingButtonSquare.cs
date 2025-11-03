using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonSquare : MonoBehaviour
{
    public GameObject buildingPrefab;
    public BuildingPlacementSystem placementSystem;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        placementSystem.StartPlacement(buildingPrefab);
    }
}
