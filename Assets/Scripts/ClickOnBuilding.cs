using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickOnBuilding : MonoBehaviour
{
    private Vector2 touchPosition;
    [SerializeField] private Camera mainCamera;
    public void OnTouch(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        Debug.Log("Ecran Touché");
        if (context.performed)
        {
            touchPosition = context.ReadValue<Vector2>();
        }
        Ray ray = mainCamera.ScreenPointToRay(touchPosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Batiment touché : " + hit.collider.name);
            if(hit.collider.CompareTag("Building"))
            {
                GameObject clickedObject = hit.collider.gameObject;

                BuildingOption batiment = clickedObject.GetComponent<BuildingOption>();
                if(batiment != null)
                {
                    batiment.OnSelected();
                }
            }
        }
    }
}

