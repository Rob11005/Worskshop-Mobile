using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bâtiment : MonoBehaviour
{
    public static Bâtiment Instance;
    public BuildingsData data;
    public int b_level;

    public void Start()
    {
        StartProduction();
        Instance = this;
        Buildings_Manager.Instance.RegisterBuilding(this);
    }
    public void StartProduction()
    {
        StartCoroutine(ProductionLoop());
    }
    

    public bool CanUpgrade()
    {
        if (b_level >= data.levels.Count - 1)
            return false;

        var nextCost = data.levels[b_level + 1].cost;
        return Ressources_Manager.Instance.HasEnoughResources(nextCost);
    }

    public void Upgrade()
    {
        CanUpgrade();
        if (!CanUpgrade()) return;

        var nextCost = data.levels[b_level + 1].cost;
        Ressources_Manager.Instance.SpendResources(nextCost);
        b_level++;
    }

    public void Produce()
    {
        var prod = data.levels[b_level].production;
        foreach (var entry in prod)
        {
            Ressources_Manager.Instance.AddResources(entry.resourceName, entry.amount);
        }
    }

    private IEnumerator ProductionLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Produce();
        }
    }

    private void OnDestroy()
{
    Buildings_Manager.Instance.UnregisterBuilding(this);
}
}
