using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Grid : MonoBehaviour
{
    private List<Tile> m_Tiles;

    [Header("Grid Creation")]

    public uint ColumnCount = 10;

    public uint RowCount = 10;

    public float CellSize = 1;

    public Color GridColor = Color.green;

    [Space]
    [Header("Grid Editor")]

    public GameObject[] AvaileTuiles;

    public int SelectedTile;

    private void Awake()
    {
        m_Tiles = GetComponentsInChildren<Tile>().ToList();

        foreach (var t in m_Tiles)
        {
            Vector2Int t_GridPos = WorldToGrid(t.transform.position);

            t.x = (uint)t_GridPos.x;
            t.y = (uint)t_GridPos.y;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(Vector3.zero, Vector3.up);
        Gizmos.color = GridColor;

        for (int i = 0; i < ColumnCount + 1; i++)
        {
            Vector3 t_depart = new Vector3(i * CellSize + transform.position.x, transform.position.y, 0);
            Vector3 t_arrivee = new Vector3(i * CellSize + transform.position.x, RowCount * CellSize + transform.position.y, 0);

            Gizmos.DrawLine(t_depart, t_arrivee);
        }

        for (int i = 0; i < RowCount + 1; i++)
        {
            Vector3 t_depart = new Vector3(transform.position.x, i * CellSize + transform.position.y, 0);
            Vector3 t_arrivee = new Vector3(ColumnCount * CellSize + transform.position.x, i * CellSize + transform.position.y, 0);

            Gizmos.DrawLine(t_depart, t_arrivee);

        }
    }

    public Vector2Int WorldToGrid(Vector3 a_worldPos)
    {
        int t_PosX = Mathf.FloorToInt((a_worldPos.x - transform.position.x) / CellSize);
        int t_PosY = Mathf.FloorToInt((a_worldPos.y - transform.position.y) / CellSize);

        if (t_PosX < 0 || t_PosX >= ColumnCount)
            throw new GridException("Out of Grid !");

        if (t_PosY < 0 || t_PosY >= RowCount)
            throw new GridException("Out of Grid !");

        return new Vector2Int(t_PosX, t_PosY);
    }

    public Vector3 GridToWorld(Vector2Int a_GridPos)
    {

        if (a_GridPos.x < 0 || a_GridPos.x >= ColumnCount)
            throw new GridException("Out of Grid !");

        if (a_GridPos.y < 0 || a_GridPos.y >= RowCount)
            throw new GridException("Out of Grid !");

        float t_PosX = a_GridPos.x * CellSize + CellSize / 2 + transform.position.x;
        float t_PosY = a_GridPos.y * CellSize + CellSize / 2 + transform.position.y;

        return new Vector3(t_PosX, t_PosY, 0);
    }

    public Tile GetTile(Vector2Int a_GridPos)
    {
        return m_Tiles.FirstOrDefault(t => t.x == (uint)a_GridPos.x && t.y == (uint)a_GridPos.y);
    }

}