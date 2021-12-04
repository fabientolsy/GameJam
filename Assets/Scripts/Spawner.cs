using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Grid Grid;
    public Pathfinder Pathfinder;
    public Transform Start, End;
    public GameObject Joueur;

 
    void Update()
    {
        Vector3 t_StartPosition = Grid.GridToWorld(Grid.WorldToGrid(Start.position));

        GameObject newEnnemi = Instantiate(Joueur, Start.position, Quaternion.identity);

        Joueur t_Ennemi = newEnnemi.GetComponent<Joueur>();
        t_Ennemi.Pathfinder = Pathfinder;
        t_Ennemi.Grid = Grid;
        t_Ennemi.Arrivee = End;
    }
}
