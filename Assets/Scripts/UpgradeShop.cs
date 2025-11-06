using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI costText;
    public Button upgradeButton;

    private Bâtiment linkedBuilding;

    public void Setup(Bâtiment building)
    {
        linkedBuilding = building;
        RefreshUI();

        upgradeButton.onClick.RemoveAllListeners();
        upgradeButton.onClick.AddListener(OnUpgradeClicked);
    }

    void RefreshUI()
    {
        costText.text = "";
        nameText.text = linkedBuilding.data.buildingName;
        levelText.text = "Niveau " + (linkedBuilding.b_level + 1);
        foreach (var r in linkedBuilding.data.levels[linkedBuilding.b_level + 1].cost)
        {
            costText.text += $"{r.resourceName} : {r.amount}\n";
        };
    }

    void OnUpgradeClicked()
    {
        linkedBuilding.Upgrade();
        RefreshUI(); // rafraîchit l’affichage après upgrade
    }
}

