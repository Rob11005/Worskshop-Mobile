using UnityEngine;

[ExecuteAlways]
public class GridRendererHexGL : MonoBehaviour
{
    public IsoGridManagerHex grid;
    public Color gridColor = new Color(0f, 1f, 0f, 0.25f);
    public float lineWidth = 1.2f;
    public bool showGrid = false; // <- toggle contrôlé par le système de placement

    private Material lineMaterial;

    void OnEnable()
    {
        if (lineMaterial == null)
        {
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader)
            {
                hideFlags = HideFlags.HideAndDontSave
            };
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    void OnRenderObject()
    {
        if (!showGrid || grid == null || lineMaterial == null) return;

        lineMaterial.SetPass(0);
        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);

        GL.Begin(GL.LINES);
        GL.Color(gridColor);

        for (int x = 0; x < grid.width; x++)
        {
            for (int z = 0; z < grid.height; z++)
            {
                Vector3 center = grid.GetWorldPosition(x, z);
                DrawHex(center, grid.cellSize * 0.5f);
            }
        }

        GL.End();
        GL.PopMatrix();
    }

    private void DrawHex(Vector3 center, float radius)
    {
        for (int i = 0; i < 6; i++)
        {
            float angle1 = Mathf.Deg2Rad * (60f * i - 30f);
            float angle2 = Mathf.Deg2Rad * (60f * (i + 1) - 30f);

            Vector3 p1 = new Vector3(
                center.x + radius * Mathf.Cos(angle1),
                center.y,
                center.z + radius * Mathf.Sin(angle1)
            );
            Vector3 p2 = new Vector3(
                center.x + radius * Mathf.Cos(angle2),
                center.y,
                center.z + radius * Mathf.Sin(angle2)
            );

            GL.Vertex(p1);
            GL.Vertex(p2);
        }
    }
}
