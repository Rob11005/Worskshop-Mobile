using UnityEngine;
using UnityEngine.UI;

public class SwitchingShopPage : MonoBehaviour
{
    public Image Buy;
    public Image Upgrade;

    public void SwitchToBuy()
    {
        Buy.gameObject.SetActive(true);
        Upgrade.gameObject.SetActive(false);
    }   

    public void SwitchToUpgrade()
    {
        Buy.gameObject.SetActive(false);
        Upgrade.gameObject.SetActive(true);
    }
}
