using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlacementSystem : MonoBehaviour
{
    public IsoGridManager grid;
    public GridRenderer gridRenderer;
    public Material ghostMaterial;
    public LayerMask groundMask;

    private GameObject currentGhost;
    private GameObject selectedBuildingPrefab;
    private bool isPlacing = false;
    private Renderer[] ghostRenderers;
    private Color validColor = new Color(0f, 1f, 0f, 0.4f);
    private Color invalidColor = new Color(1f, 0f, 0f, 0.4f);

    void Update()
    {
        if (!isPlacing || selectedBuildingPrefab == null) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
        {
            Vector3 worldPos = hit.point;
            int x = Mathf.RoundToInt(worldPos.x / grid.cellSize);
            int z = Mathf.RoundToInt(worldPos.z / grid.cellSize);

            if (grid.IsInsideGrid(x, z))
            {
                Vector3 cellPos = grid.GetWorldPosition(x, z);
                currentGhost.transform.position = cellPos;

                bool canPlace = grid.IsCellFree(x, z);

                // Couleur du fantôme
                foreach (var r in ghostRenderers)
                    r.material.color = canPlace ? validColor : invalidColor;

                // Clic gauche  placement
                if (Input.GetMouseButtonDown(0) && canPlace)
                    PlaceBuilding(cellPos, x, z);
            }
        }

        // Clic droit  annuler
        if (Input.GetMouseButtonDown(1))
            CancelPlacement();
    }

    public void StartPlacement(GameObject buildingPrefab)
    {
        if (isPlacing) CancelPlacement();

        selectedBuildingPrefab = buildingPrefab;
        currentGhost = Instantiate(buildingPrefab);
        isPlacing = true;

        // Appliquer le matériau du fantôme
        ghostRenderers = currentGhost.GetComponentsInChildren<Renderer>();
        foreach (var renderer in ghostRenderers)
        {
            renderer.material = new Material(ghostMaterial);
            renderer.material.color = validColor;
        }

        // Afficher la grille
        gridRenderer.DrawGrid();
    }

    private void PlaceBuilding(Vector3 position, int x, int z)
    {
        Instantiate(selectedBuildingPrefab, position, Quaternion.identity);
        grid.SetOccupied(x, z, true);
        CancelPlacement();
    }

    private void CancelPlacement()
    {
        if (currentGhost != null) Destroy(currentGhost);
        gridRenderer.ClearGrid();
        isPlacing = false;
        selectedBuildingPrefab = null;
    }
}

