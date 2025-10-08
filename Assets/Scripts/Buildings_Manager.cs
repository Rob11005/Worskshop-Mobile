using UnityEngine;

public class Buildings_Manager : MonoBehaviour
{
    public static Buildings_Manager Instance;
    public Transform buildingParent;

    void Awake()
    {
        Instance = this;
    }

    public void PlaceBuilding(BuildingsData data)
    {
        GameObject prefab = data.prefab;
        GameObject buildingGO = Instantiate(prefab, Vector3.zero, Quaternion.identity, buildingParent);

        Bâtiment batiment = buildingGO.GetComponent<Bâtiment>();
        batiment.data = data;
        batiment.b_level = 0;
    }    
}
