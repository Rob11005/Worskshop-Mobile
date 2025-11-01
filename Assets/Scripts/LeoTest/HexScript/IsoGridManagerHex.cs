using UnityEngine;

public class IsoGridManagerHex : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;

    private bool[,] occupied;

    void Awake()
    {
        occupied = new bool[width, height];
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        float offsetX = (z % 2 == 0) ? 0 : cellSize * 0.5f;
        float worldX = x * cellSize + offsetX;
        float worldZ = z * (cellSize * 0.866f); // 0.866 = V3 / 2
        return transform.position + new Vector3(worldX, 0, worldZ);
    }

    public bool IsInsideGrid(int x, int z)
    {
        return x >= 0 && x < width && z >= 0 && z < height;
    }

    public bool IsCellFree(int x, int z)
    {
        return !occupied[x, z];
    }

    public void SetOccupied(int x, int z, bool state)
    {
        occupied[x, z] = state;
    }

    public Vector2Int GetCellFromWorld(Vector3 worldPos)
    {
        float q = (worldPos.x * 2f / 3f) / cellSize;
        float r = (-worldPos.x / 3f + Mathf.Sqrt(3f) / 3f * worldPos.z) / cellSize;
        int x = Mathf.RoundToInt(q);
        int z = Mathf.RoundToInt(r);
        return new Vector2Int(x, z);
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    Vector3 center = GetWorldPosition(x, z);
                    Vector3[] corners = new Vector3[7];
                    for (int i = 0; i < 7; i++)
                    {
                        float angleDeg = 60f * i - 30f;
                        float angleRad = Mathf.Deg2Rad * angleDeg;
                        corners[i] = new Vector3(
                            center.x + (cellSize * 0.5f) * Mathf.Cos(angleRad),
                            center.y,
                            center.z + (cellSize * 0.5f) * Mathf.Sin(angleRad)
                        );
                    }

                    for (int i = 0; i < 6; i++)
                        Gizmos.DrawLine(corners[i], corners[i + 1]);
                }
            }
        }
    }

}
