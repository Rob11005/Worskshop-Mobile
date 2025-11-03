using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GridRenderer : MonoBehaviour
{
    public IsoGridManager grid;
    public Color gridColor = new Color(0f, 1f, 0f, 0.25f);
    public float lineWidth = 0.02f;

    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.loop = false;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
        lineRenderer.material.color = gridColor;
    }

    public void DrawGrid()
    {
        if (grid == null) return;

        int lines = (grid.width + 1) + (grid.height + 1);
        int points = lines * 2;
        Vector3[] positions = new Vector3[points];

        int index = 0;
        for (int x = 0; x <= grid.width; x++)
        {
            positions[index++] = grid.transform.position + new Vector3(x * grid.cellSize, 0, 0);
            positions[index++] = grid.transform.position + new Vector3(x * grid.cellSize, 0, grid.height * grid.cellSize);
        }

        for (int z = 0; z <= grid.height; z++)
        {
            positions[index++] = grid.transform.position + new Vector3(0, 0, z * grid.cellSize);
            positions[index++] = grid.transform.position + new Vector3(grid.width * grid.cellSize, 0, z * grid.cellSize);
        }

        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }

    public void ClearGrid()
    {
        lineRenderer.positionCount = 0;
    }
}
