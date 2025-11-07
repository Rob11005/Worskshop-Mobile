using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bâtiment : MonoBehaviour
{
    public static Bâtiment Instance;
    public BuildingsData data;
    public int b_level;
    public TextMeshProUGUI upgradeFeedback;

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
        if (!CanUpgrade())
        {
            upgradeFeedback.text = "";
            upgradeFeedback.text = "Pas assez de ressources";
            upgradeFeedback.enabled = true;
            StartCoroutine(ShowingUpgradeFeedback());
            return;
        }
        else
        {
            upgradeFeedback.text = "";
            upgradeFeedback.text = "Bâtiment amélioré !";
            upgradeFeedback.enabled = true;
            StartCoroutine(ShowingUpgradeFeedback());
        }
        


        var nextCost = data.levels[b_level + 1].cost;
        Ressources_Manager.Instance.SpendResources(nextCost);
        ShowingResources.Instance.UpdateResources();
        b_level++;
    }

    public void Produce()
    {
        var prod = data.levels[b_level].production;
        foreach (var entry in prod)
        {
            Ressources_Manager.Instance.AddResources(entry.resourceName, entry.amount);
            ShowingResources.Instance.UpdateResources();
        }
    }

    private IEnumerator ProductionLoop()
    {
        while (true)
        {
            Produce();
            yield return new WaitForSeconds(data.productionTime);
        }
    }

    private void OnDestroy()
    {
        Buildings_Manager.Instance.UnregisterBuilding(this);
    }

    IEnumerator ShowingUpgradeFeedback()
    {
        yield return new WaitForSeconds(2f);
        upgradeFeedback.enabled = false;
    }
}
