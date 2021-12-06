using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int Gold = 100;
    public int VieJoueur = 5;
    public static GameManager Instance;

    private int t_actualScene;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        t_actualScene = SceneManager.GetActiveScene().buildIndex;

        if(t_actualScene == 2)
        {
            SceneManager.LoadScene("Fight");
        }
    }
}
