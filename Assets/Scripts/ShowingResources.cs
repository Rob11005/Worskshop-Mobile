using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShowingResources : MonoBehaviour
{
    public static ShowingResources Instance;
    public GameObject resourcesTextGO;
    public TextMeshProUGUI resourcesText;
    public GameObject resourcesTextBackground;
    bool isOpen = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void UpdateResources()
    {
        resourcesText.text = "";
        foreach (var i in Ressources_Manager.Instance._ressources)
            {
                resourcesText.text += i.Key + "=" + i.Value + "\n";
            }
    }

    public void Show()
    {
        if (!isOpen)
        {
            resourcesTextBackground.SetActive(true);
            resourcesTextGO.SetActive(true);
            isOpen = true;
        }
        else
        {
            resourcesText.text = "";
            resourcesTextBackground.SetActive(false);
            resourcesTextGO.SetActive(false);
            isOpen = false;
        }
    }
}
