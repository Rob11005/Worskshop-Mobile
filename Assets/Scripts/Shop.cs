using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public BuildingsData datas;
    public Button button;
    public Image icon;
    public TextMeshProUGUI costText;

    private void Start()
    {
        icon.sprite = datas.buildingIcon;
        UpdateCostText();

        button.onClick.AddListener(OnBuyClicked);
    }

    void UpdateCostText()
    {
        string text = "";

        foreach (var r in datas.levels[0].cost)
        {
            text += $"{r.resourceName} : {r.amount}\n";
        }
        costText.text = text;
    }

    void OnBuyClicked()
    {
        if (Ressources_Manager.Instance.HasEnoughResources(datas.levels[0].cost))
        {
            Ressources_Manager.Instance.SpendResources(datas.levels[0].cost);
            Buildings_Manager.Instance.PlaceBuilding(datas);
        }
        else
        {
            Debug.Log("Pas assez de ressources");
        }
    }


}
