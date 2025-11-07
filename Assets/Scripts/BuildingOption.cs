using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingOption : MonoBehaviour
{
    public GameObject buildingInfo;
    public Button button;
    public BuildingsData datas;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI prodText;
    public TextMeshProUGUI costText;
    private Bâtiment bat;

    void Awake()
    {
        bat = GetComponent<Bâtiment>();
        nameText.text = datas.buildingName;
        foreach (var r in datas.levels[bat.b_level].production)
        {
            prodText.text += $"{r.resourceName} : {r.amount}\n";
        }
        foreach(var r in datas.levels[bat.b_level + 1].cost)
        {
            costText.text += $"{r.resourceName} : {r.amount}\n";
        }
        button.onClick.AddListener(OnClicked);
    }
    public void OnSelected()
    {
        buildingInfo.SetActive(true);
    }

    public void OnUpgrade()
    {
        bat.Upgrade();
        costText.text = "";
        foreach(var r in datas.levels[bat.b_level + 1].cost)
        {
            costText.text += $"{r.resourceName} : {r.amount}\n";
        }
    }

    public void OnClicked()
    {
        buildingInfo.SetActive(false);
    }

}
