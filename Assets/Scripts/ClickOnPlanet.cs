using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;
using NUnit.Framework;

public class ClickOnPlanet : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    Vector2 touchPosition;
    RaycastHit hit;
    public CinemachineCamera cameraP1;
    public CinemachineCamera cameraP2;
    public Canvas manageButton;
    public string actualPlanet;


    void Awake()
    {
        cameraP1.enabled = false;
        cameraP2.enabled = false;
        manageButton.enabled = false;
    }
    public void OnTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Ecran Touché");
        if (context.performed)
        {
            touchPosition = context.ReadValue<Vector2>();
        }
        Ray ray = mainCamera.ScreenPointToRay(touchPosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Objet touché : " + hit.collider.name);
            if (hit.collider.name == "Planète 1")
            {
                cameraP1.enabled = true;
                manageButton.enabled = true;
                actualPlanet = "Planète 1";
            }
            else if (hit.collider.name == "Planète 2")
            {
                cameraP2.enabled = true;
                manageButton.enabled = true;
                actualPlanet = "Planète 2";
            }
        }

    }

    public void Return()
    {
        cameraP1.enabled = false;
        cameraP2.enabled = false;
        manageButton.enabled = false;
        actualPlanet = null;
    }

    public void EnterPlanet()
    {
        SceneManager.LoadScene(actualPlanet);
    }
}
