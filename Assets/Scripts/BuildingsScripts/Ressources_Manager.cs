using System.Collections.Generic;
using UnityEngine;

public class Ressources_Manager : MonoBehaviour
{
    public static Ressources_Manager Instance;
    public Dictionary<string, int> _ressources = new Dictionary<string, int>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        IniatializeResources();
    }

    void Update()
    {
        foreach (var i in _ressources)
        {
            Debug.Log(i.Key + " = " + i.Value);
        }
    }

    private void IniatializeResources()
    {
        
    }

    public int GetResources(string name) => _ressources.TryGetValue(name, out int value) ? value : 0;

    public void AddResources(string name, int amount)
    {
        if (!_ressources.ContainsKey(name))
        {
            _ressources[name] = 0;
        }
        _ressources[name] += amount;

    }

    public bool HasEnoughResources(List<ResourceAmount> cost)
    {
        foreach (var entry in cost)
        {
            if (GetResources(entry.resourceName) < entry.amount)
            {
                return false;
            }
        }
        return true;
    }
    public void SpendResources(List<ResourceAmount> cost    )
    {
        foreach (var entry in cost)
        {
            _ressources[entry.resourceName] -= entry.amount;
        }
    }


}
