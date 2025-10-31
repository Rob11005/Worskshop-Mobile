using UnityEngine;
using UnityEngine.UI;

public class SwitchingShopPage : MonoBehaviour
{
    public Image Buy;
    public Image Upgrade;

    public GameObject upgradeItemPrefab;
    public Transform contentParent;    

    public void SwitchToBuy()
    {
        Buy.gameObject.SetActive(true);
        Upgrade.gameObject.SetActive(false);
    }   

    public void SwitchToUpgrade()
    {
        Buy.gameObject.SetActive(false);
        Upgrade.gameObject.SetActive(true);
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);
         foreach (Bâtiment building in Buildings_Manager.Instance.allBuildings)
        {
            GameObject itemGO = Instantiate(upgradeItemPrefab, contentParent);
            UpgradeShop itemUI = itemGO.GetComponent<UpgradeShop>();
            itemUI.Setup(building);
        }
    }
}
