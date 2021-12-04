using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int Gold = 100;
    public int VieJoueur = 5;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
}
