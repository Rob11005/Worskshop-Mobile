using UnityEngine;

public class MineCalcite : MonoBehaviour
{
    public BuildingsData data;
    public int b_level;

    public bool CanBuy()
    {
        if (b_level >= data.levels.Count - 1)
            return false;

        var nextCost = data.levels[b_level].cost;
        return Ressources_Manager.Instance.HasEnoughResources(nextCost);
    }

    public void Buy()
    {
        if (!CanBuy()) return;

        var nextCost = data.levels[b_level].cost;
        Ressources_Manager.Instance.SpendResources(nextCost);    
    }
}
