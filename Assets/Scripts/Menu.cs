using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text textTitre;

    private void Start()
    {
        textTitre.text = "Free Guy !";
    }

    public void BoutonJouer()
    {
        Debug.Log("Jouer !");
        SceneManager.LoadScene("Plateau1");
    }

    public void BoutonQuitter()
    {
        Debug.Log("Quitter !");
        Application.Quit();
    }
}
