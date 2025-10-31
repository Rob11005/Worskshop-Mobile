using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
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
        nameText.text = linkedBuilding.data.buildingName;
        levelText.text = "Niveau " + (linkedBuilding.b_level + 1);
    }

    void OnUpgradeClicked()
    {
        linkedBuilding.Upgrade();
        RefreshUI(); // rafraîchit l’affichage après upgrade
    }
}

