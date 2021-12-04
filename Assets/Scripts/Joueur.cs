using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public Path CurrentPath;
    public Transform Arrivee;
    public Grid Grid;
    public Pathfinder Pathfinder;
    public float Speed = 10;
    public int Vie = 2;

    public AudioClip[] SpwanSounds;

    private int m_TargetCheckpoint;
    private AudioSource m_AS;

    private void Awake()
    {
        m_AS = gameObject.gameObject.GetComponent<AudioSource>();

    }

    private void Start()
    {
        // Jouer un son
        /*int soundId = Random.Range(0, SpwanSounds.Length);
        m_AS.PlayOneShot(SpwanSounds[soundId]);*/
    }

    private void Update()
    {
       
        if (CurrentPath == null)
            CalculatePath();

        if (CurrentPath == null)
            return;

        if (ReachedCheckpoint())
        {

            CalculatePath();

            if (CurrentPath == null)
                return;

            // Passe au prochain chekpoint
            m_TargetCheckpoint = 1;

            // Detruie si l'ennemi arrive a la fin du parcours
            if(m_TargetCheckpoint == CurrentPath.Checkpoints.Count)
            {
                Remove();
                GameManager.Instance.VieJoueur -= 1;
                return;
            }

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
        Tile t_StartTile = Grid.GetTile(Grid.WorldToGrid(transform.position));
        Tile t_EndTile = Grid.GetTile(Grid.WorldToGrid(Arrivee.position));

        CurrentPath = Pathfinder.GetPath(t_StartTile, t_EndTile, false);
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
