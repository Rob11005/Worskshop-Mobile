using UnityEngine;

[ExecuteAlways]
public class IsoGridManagerHex : MonoBehaviour
{
    [Header("Grid Settings")]
    [Tooltip("Rayon de la grille hexagonale (distance du centre au bord en nombre de cases).")]
    public int radius = 5;
    [Tooltip("Taille d'une cellule hexagonale (du centre à un coin).")]
    public float cellSize = 1f;

    private bool[,] occupied;

    void Awake()
    {
        int size = radius * 2 + 1;
        occupied = new bool[size, size];
    }

    // --- Coordonnées grille  monde (flat-top)
    public Vector3 GetWorldPosition(int q, int r)
    {
        float x = cellSize * Mathf.Sqrt(3f) * (q + r * 0.5f);
        float z = cellSize * 1.5f * r;
        return transform.position + new Vector3(x, 0f, z);
    }

    // --- Coordonnées monde  grille (flat-top)
    public Vector2Int GetCellFromWorld(Vector3 worldPos)
    {
        worldPos -= transform.position;

        float q = (Mathf.Sqrt(3f) / 3f * worldPos.x - 1f / 3f * worldPos.z) / cellSize;
        float r = (2f / 3f * worldPos.z) / cellSize;

        int rq = Mathf.RoundToInt(q);
        int rr = Mathf.RoundToInt(r);

        return new Vector2Int(rq, rr);
    }

    public bool IsInsideGrid(int q, int r)
    {
        return Mathf.Abs(q) <= radius && Mathf.Abs(r) <= radius && Mathf.Abs(q + r) <= radius;
    }

    public bool IsCellFree(int q, int r)
    {
        int i = q + radius;
        int j = r + radius;
        if (i < 0 || j < 0 || i >= occupied.GetLength(0) || j >= occupied.GetLength(1))
            return false;
        return !occupied[i, j];
    }

    public void SetOccupied(int q, int r, bool state)
    {
        int i = q + radius;
        int j = r + radius;
        if (i < 0 || j < 0 || i >= occupied.GetLength(0) || j >= occupied.GetLength(1))
            return;
        occupied[i, j] = state;
    }

    // --- Gizmos cohérent avec la grille hexagonale
    void OnDrawGizmos()
    {
        if (cellSize <= 0) return;

        Gizmos.color = new Color(0f, 1f, 0f, 0.4f);

        for (int q = -radius; q <= radius; q++)
        {
            for (int r = -radius; r <= radius; r++)
            {
                int s = -q - r;
                if (Mathf.Abs(s) > radius) continue; // garde une forme ronde/hexagonale

                Vector3 center = GetWorldPosition(q, r);
                DrawHexGizmo(center, cellSize);
            }
        }
    }

    private void DrawHexGizmo(Vector3 center, float radius)
    {
        Vector3[] corners = new Vector3[7];
        for (int i = 0; i < 7; i++)
        {
            float angleDeg = 60f * i - 30f; // flat-top
            float angleRad = Mathf.Deg2Rad * angleDeg;
            corners[i] = new Vector3(
                center.x + radius * Mathf.Cos(angleRad),
                center.y,
                center.z + radius * Mathf.Sin(angleRad)
            );
        }

        for (int i = 0; i < 6; i++)
            Gizmos.DrawLine(corners[i], corners[i + 1]);
    }
}



