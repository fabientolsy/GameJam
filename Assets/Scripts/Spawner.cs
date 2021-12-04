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

        GameObject newJoueur = Instantiate(Joueur, Start.position, Quaternion.identity);

        Joueur t_Joueur = newJoueur.GetComponent<Joueur>();
        t_Joueur.Pathfinder = Pathfinder;
        t_Joueur.Grid = Grid;
        t_Joueur.Arrivee = End;
    }
}
