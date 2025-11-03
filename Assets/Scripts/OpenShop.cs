using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{
    public GameObject shopGO;
    public GameObject exitButton;
    public void ActiveCanvasShop()
    {
        shopGO.SetActive(true);
        exitButton.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitCanvasShop()
    {
        shopGO.SetActive(false);
        exitButton.SetActive(false);
        gameObject.SetActive(true);
    }
}
