using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
    public GameObject buildingPrefab;
    public BuildingPlacementSystemHex placementSystem;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        placementSystem.StartPlacement(buildingPrefab);
    }
}
