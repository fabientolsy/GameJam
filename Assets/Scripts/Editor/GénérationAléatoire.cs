using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Grid))]
public class GenerationAleatoire : Editor
{

    private Grid m_Grid;

    public List<Transform> Objets;

    private void OnEnable()
    {
        m_Grid = (Grid)target;


    }

    private void OnSceneGUI()
    {



        if (Event.current.type == EventType.MouseDown && Event.current.control)
        {

            // Prevenir la selection par defaut
            GUIUtility.hotControl = GUIUtility.GetControlID(FocusType.Passive);

            // Trouver la position cliquee 
            Vector3 t_ClickPos = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;

            // Transformer la position dans le monde de la scene en position dans la grille
            Vector2Int t_GridPos = m_Grid.WorldToGrid(t_ClickPos);
            Debug.Log("Grid Click at " + t_GridPos);

            // Transformer la position dans la grille en position dans le monde de la scene, pour trouver le centre de la cellule
            Vector3 t_WorldPos = m_Grid.GridToWorld(t_GridPos);
            Debug.Log("Word Click at " + t_WorldPos);

            // Spawnner une tuile
            if (m_Grid.SelectedTile < 0 || m_Grid.SelectedTile >= m_Grid.AvaileTuiles.Length)
                throw new GridException("Selected out of bounds !");


            GameObject t_TilePefabs = m_Grid.AvaileTuiles[m_Grid.SelectedTile]; // Selection de la tuile a afficher de la liste 

            // Supprimer l'ancienne tuile si il y en a deja une ou on veux en faire spwan une
            List<Tile> t_Tiles = m_Grid.GetComponentsInChildren<Tile>().ToList();
            Tile t_OldTile = t_Tiles.FirstOrDefault(t => t_GridPos == m_Grid.WorldToGrid(t.transform.position));

            if (t_OldTile != null)
            {
                Undo.DestroyObjectImmediate(t_OldTile.gameObject);
            }

            // Spawner la nouvelle tuile
            GameObject t_NewTile = (GameObject)PrefabUtility.InstantiatePrefab(t_TilePefabs, m_Grid.transform);

            Undo.RegisterCreatedObjectUndo(t_NewTile, "Tile Created"); // Enregistrement dans le cas ou on souhaite faire un Ctrl + Z

            t_NewTile.transform.position = t_WorldPos;

            Sprite t_Sprite = t_NewTile.GetComponent<SpriteRenderer>().sprite;
            float t_NewScale = m_Grid.CellSize / t_Sprite.bounds.size.x;
            t_NewTile.transform.localScale = new Vector3(t_NewScale, t_NewScale, t_NewScale);
        }
    }
}
