using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using static UnityEngine.GraphicsBuffer;

public class Joueur : MonoBehaviour 
{
    public Path CurrentPath;
    
    public Vector3 Arrivee;
    public float Speed = 10;
    public int Vie = 2;

    public Transform Depart;

    public AudioClip[] SpwanSounds;

    private int m_TargetCheckpoint;
    private AudioSource m_AS;

    private Grid m_Grid;
    private Pathfinder m_Pathfinder;

    public VectorValue startingPosition;



    private void Awake()
    {
        m_AS = gameObject.gameObject.GetComponent<AudioSource>();

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        // Jouer un son
        /*int soundId = Random.Range(0, SpwanSounds.Length);
        m_AS.PlayOneShot(SpwanSounds[soundId]);*/

        Depart.transform.position = gameObject.GetComponent<Transform>().position;
        m_Grid = GameObject.Find("Grid").GetComponent<Grid>();
        m_Pathfinder = m_Grid.GetComponent<Pathfinder>();
        transform.position = startingPosition.initialValue;
    }

    private void Update()
    {
        //Depart = gameObject.GetComponent<Transform>();

        if (Input.GetMouseButtonDown(0))
        {
            // Trouver la position cliquee 
            //Vector3 t_ClickPos = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
            Vector3 t_ClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Position cliquee "+Input.mousePosition);
            Debug.Log("Joueur Update" + t_ClickPos);

            // Transformer la position dans le monde de la scene en position dans la grille
            Vector2Int t_GridPos = m_Grid.WorldToGrid(t_ClickPos);
            Debug.Log("Grid Click at " + t_GridPos);

            // Transformer la position dans la grille en position dans le monde de la scene, pour trouver le centre de la cellule
            Vector3 t_WorldPos = m_Grid.GridToWorld(t_GridPos);
            Debug.Log("Word Click at " + t_WorldPos);

            // Spawnner une tuile
            if (m_Grid.SelectedTile < 0 || m_Grid.SelectedTile >= m_Grid.AvaileTuiles.Length)
                throw new GridException("Selected out of bounds !");

            Arrivee = t_WorldPos;
            
            CalculatePath();
        }

        if (CurrentPath == null)
        {
            return;
        }

        if ( ReachedCheckpoint())
        {

            CalculatePath();

            if (CurrentPath == null)
                return;

            // Passe au prochain chekpoint
            m_TargetCheckpoint = 1;

            // Detruie si l'ennemi arrive a la fin du parcours
            /*if(m_TargetCheckpoint == CurrentPath.Checkpoints.Count)
            {
                Remove();
                GameManager.Instance.VieJoueur -= 1;
                return;
            }*/

            // Detruire s l'ennemi n'a plus de vie
            if (Vie <= 0)
            {
                Remove();
                return;
            }
        }

        // Deplacement vers prochain chekpoint
        Vector3 direction = (CurrentPath.Checkpoints[m_TargetCheckpoint].transform.position - transform.position).normalized;
        Vector3 deplacement = direction * Speed * Time.deltaTime;

        if (deplacement.magnitude > DistanceFromTrget())
        {
            transform.position = CurrentPath.Checkpoints[m_TargetCheckpoint].transform.position;
        }
        else
        {
            transform.position += deplacement;
        }
        
    }

    private bool ReachedCheckpoint()
    {
        float t_TargetDistance = DistanceFromTrget();
        
        return t_TargetDistance < 0.1;
    }

    private float DistanceFromTrget()
    {
        return Vector3.Distance(CurrentPath.Checkpoints[m_TargetCheckpoint].transform.position, transform.position);
    }

    private void CalculatePath()
    {
        Debug.Log("CalculatePath");

        Tile t_StartTile = m_Grid.GetTile(m_Grid.WorldToGrid(transform.position));
        Debug.Log("t_StartTile = " + t_StartTile);
        Tile t_EndTile = m_Grid.GetTile(m_Grid.WorldToGrid(Arrivee));
        Debug.Log(t_EndTile);

        CurrentPath = m_Pathfinder.GetPath(t_StartTile, t_EndTile, true);
        Debug.Log(CurrentPath);
    }

    private void OnDrawGizmosSelected()
    {
        if (CurrentPath == null)
            return;

        for(int i = 0; i < CurrentPath.Checkpoints.Count - 1; i++)
        {
            Transform currentCP = CurrentPath.Checkpoints[i].transform;
            Transform nextCP = CurrentPath.Checkpoints[i + 1].transform;

            Gizmos.DrawLine(currentCP.position, nextCP.position);
        }
    }

    public void Remove()
    {
        Destroy(gameObject);
        /*GameManager.Instance.Ennemies.Remove(this);
        GameManager.Instance.Gold += 50;*/
    }
}
