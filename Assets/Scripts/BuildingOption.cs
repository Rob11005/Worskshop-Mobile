using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class BuildingOption : MonoBehaviour
{
    public GameObject buildingInfo;
    public Button button;

    void Awake()
    {
        button.onClick.AddListener(OnClicked);
    }
    public void OnSelected()
    {
        buildingInfo.SetActive(true);
    }

    public void OnClicked()
    {
        buildingInfo.SetActive(false);
    }

}
