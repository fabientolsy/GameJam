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
    public GameObject[] RandomObject;

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

        for (int i = 0; i < RandomObject.Length; i++)
        {
            float PositionX = Random.Range(1, ColumnCount - 1);
            float PositionY = Random.Range(1, RowCount - 1);
            Vector2 ObjetPos = new Vector2(PositionY, PositionX);
            Vector2Int t_GridPos = WorldToGrid(ObjetPos);
            Vector3 t_WorldPos = GridToWorld(t_GridPos);

            Tile t_tileWMur = GetTile(t_GridPos);

            if (t_tileWMur != AvaileTuiles[0])
            {

                int ObjetsAleatoire = Random.Range(0, RandomObject.Length);

                if (t_WorldPos.x == ColumnCount || t_WorldPos.x == ColumnCount - 1)
                {
                    t_WorldPos.x = t_WorldPos.x - 1;
                }

                if (t_WorldPos.x == 0 || t_WorldPos.x == 1)
                {
                    t_WorldPos.x = t_WorldPos.x + 1;
                }

                if (t_WorldPos.y == RowCount || t_WorldPos.y == RowCount - 1)
                {
                    t_WorldPos.y = t_WorldPos.y - 1;
                }

                if (t_WorldPos.y == 0 || t_WorldPos.y == 1)
                {
                    t_WorldPos.y = t_WorldPos.y + 1;
                }            

                GameObject randPrefab = RandomObject[ObjetsAleatoire];

                // Variables nécessaires pour le switch
                GameObject randPrefabp2;
                GameObject randPrefabp3;
                GameObject randPrefabp4;

                float PositionX2;
                float PositionX3;
                float PositionX4;

                float PositionY2;
                float PositionY3;
                float PositionY4;

                Vector2 ObjetPos2;
                Vector2 ObjetPos3;
                Vector2 ObjetPos4;

                Vector2Int t_GridPos2;
                Vector2Int t_GridPos3;
                Vector2Int t_GridPos4;

                Vector3 t_WordPos2;
                Vector3 t_WordPos3;
                Vector3 t_WordPos4;

                switch (randPrefab)
                {
                    
                    case RandomObject[0]:
                        randPrefab.transform.position = ObjetPos;

                        randPrefabp2 = RandomObject[1];

                        PositionX2 = PositionX - 1;
                        ObjetPos2 = new Vector2(PositionX2, PositionY);
                        t_GridPos2 = WorldToGrid(ObjetPos2);
                        t_WordPos2 = GridToWorld(t_GridPos2);

                        Instantiate(RandomObject[ObjetsAleatoire], new Vector3(t_WorldPos.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();
                        Instantiate(RandomObject[1], new Vector3(t_WordPos2.x, t_WorldPos.y,0), transform.rotation).GetComponent<Tile>();
                        //Instantiate(RandomObject[ObjetsAleatoire], new Vector3(t_WorldPos.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();

                        return;

                    case RandomObject[1]:
                        randPrefab.transform.position = ObjetPos;

                        randPrefabp2 = RandomObject[0];

                        PositionX2 = PositionX + 1;
                        ObjetPos2 = new Vector2(PositionX2, PositionY);
                        t_GridPos2 = WorldToGrid(ObjetPos2);
                        t_WordPos2 = GridToWorld(t_GridPos2);

                        Instantiate(RandomObject[ObjetsAleatoire], new Vector3(t_WorldPos.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();
                        Instantiate(RandomObject[1], new Vector3(t_WordPos2.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();
                        //Instantiate(RandomObject[ObjetsAleatoire], new Vector3(t_WorldPos.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();
                        return;

                    case RandomObject[2]:
                        randPrefab.transform.position = ObjetPos;

                        randPrefabp2 = RandomObject[3];

                        PositionX2 = PositionX - 1;
                        ObjetPos2 = new Vector2(PositionX2, PositionY);
                        t_GridPos2 = WorldToGrid(ObjetPos2);
                        t_WordPos2 = GridToWorld(t_GridPos2);

                        Instantiate(RandomObject[ObjetsAleatoire], new Vector3(t_WorldPos.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();
                        Instantiate(RandomObject[3], new Vector3(t_WordPos2.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();
                        //Instantiate(RandomObject[ObjetsAleatoire], new Vector3(t_WorldPos.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();

                        return;

                    case RandomObject[3]:
                        randPrefab.transform.position = ObjetPos;

                        randPrefabp2 = RandomObject[2];

                        PositionX2 = PositionX + 1;
                        ObjetPos2 = new Vector2(PositionX2, PositionY);
                        t_GridPos2 = WorldToGrid(ObjetPos2);
                        t_WordPos2 = GridToWorld(t_GridPos2);

                        Instantiate(RandomObject[ObjetsAleatoire], new Vector3(t_WorldPos.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();
                        Instantiate(RandomObject[2], new Vector3(t_WordPos2.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();
                        //Instantiate(RandomObject[ObjetsAleatoire], new Vector3(t_WorldPos.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();
                        return;

                    case RandomObject[4]: // Morceau de tapis bas droite
                        randPrefab.transform.position = ObjetPos;

                        // Morceau bas gauche
                        randPrefabp2 = RandomObject[5];

                        // Morceau haut droite
                        randPrefabp3 = RandomObject[6];

                        // Morceau haut gauche
                        randPrefabp4 = RandomObject[7];

                        PositionX2 = PositionX - 1;
                        PositionY3 = PositionY + 1;

                        ObjetPos2 = new Vector2(PositionX2, PositionY);
                        ObjetPos3 = new Vector2(PositionX, PositionY3);
                        ObjetPos4 = new Vector2(PositionX2, PositionY3);

                        t_GridPos2 = WorldToGrid(ObjetPos2);
                        t_GridPos3 = WorldToGrid(ObjetPos3);
                        t_GridPos4 = WorldToGrid(ObjetPos4);

                        t_WordPos2 = GridToWorld(t_GridPos2);
                        t_WordPos3 = GridToWorld(t_GridPos3);
                        t_WordPos4 = GridToWorld(t_GridPos4);

                        Instantiate(RandomObject[ObjetsAleatoire], new Vector3(t_WorldPos.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();
                        
                        // Morceau bas gauche
                        Instantiate(RandomObject[5], new Vector3(t_WordPos2.x, t_WorldPos.y,0), transform.rotation).GetComponent<Tile>();
                        // Morceau haut droite
                        Instantiate(RandomObject[6], new Vector3(t_WorldPos.x, t_WordPos3.y,0), transform.rotation).GetComponent<Tile>();

                        // Morceau haut gauche
                        Instantiate(RandomObject[7], new Vector3(t_WordPos2.x, t_WordPos3.y,0), transform.rotation).GetComponent<Tile>();

                    default:
                        randPrefab.transform.position = ObjetPos;
                        Tile tileAdd = Instantiate(RandomObject[ObjetsAleatoire], new Vector3(t_WorldPos.x, t_WorldPos.y, 0), transform.rotation).GetComponent<Tile>();
                        tileAdd.x = (uint)t_GridPos.x;
                        tileAdd.y = (uint)t_GridPos.y;

                        m_Tiles.Add(tileAdd);

                        Tile s_tuile = GetTile(t_GridPos);
                        m_Tiles.Remove(s_tuile);
                        Destroy(s_tuile.gameObject);
                        Debug.Log(s_tuile.gameObject);
                        return;

                }

                
            }
            else
            {
                return;
            }
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
