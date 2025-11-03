using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToSolarSystem : MonoBehaviour
{
   public void BackToSystem()
    {
        SceneManager.LoadScene("Menu");
    }
}
