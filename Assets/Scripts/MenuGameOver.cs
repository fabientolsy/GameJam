using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameOver : MonoBehaviour
{
    public void BoutonMenu()
    {
        Debug.Log("Menu !");
        SceneManager.LoadScene("StartMenu");
    }

    public void BoutonRejouer()
    {
        Debug.Log("Rejouer !");
        SceneManager.LoadScene("Plateau1");
    }
}
