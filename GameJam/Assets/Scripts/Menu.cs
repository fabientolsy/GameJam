using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject fenetreCredits;
    public Text textTitre;

    private void Start()
    {
        textTitre.text = "Free Guy !";
    }

    public void BoutonJouer()
    {
        Debug.Log("Jouer !");
        SceneManager.LoadScene("SampleScene");
    }

    public void BoutonQuitter()
    {
        Debug.Log("Quitter !");

        Application.Quit(); // A esseyer
    }
}

