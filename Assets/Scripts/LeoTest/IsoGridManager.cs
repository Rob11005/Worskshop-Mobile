using UnityEngine;

public class IsoGridManager : MonoBehaviour
{
    public int width = 20;
    public int height = 20;
    public float cellSize = 1f;
    public bool showGridGizmos = false;

    private bool[,] occupied;

    private void Awake()
    {
        occupied = new bool[width, height];
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x * cellSize, 0, z * cellSize);
    }

    public bool IsInsideGrid(int x, int z)
    {
        return x >= 0 && z >= 0 && x < width && z < height;
    }

    public bool IsCellFree(int x, int z)
    {
        return IsInsideGrid(x, z) && !occupied[x, z];
    }

    public void SetOccupied(int x, int z, bool state)
    {
        if (IsInsideGrid(x, z))
            occupied[x, z] = state;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!showGridGizmos) return;

        Gizmos.color = new Color(0f, 1f, 0f, 0.25f);
        for (int x = 0; x <= width; x++)
        {
            Vector3 from = new Vector3(x * cellSize, 0, 0);
            Vector3 to = new Vector3(x * cellSize, 0, height * cellSize);
            Gizmos.DrawLine(transform.position + from, transform.position + to);
        }
        for (int z = 0; z <= height; z++)
        {
            Vector3 from = new Vector3(0, 0, z * cellSize);
            Vector3 to = new Vector3(width * cellSize, 0, z * cellSize);
            Gizmos.DrawLine(transform.position + from, transform.position + to);
        }
    }
#endif
}
