using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCagibitIn : MonoBehaviour
{
    public void OpenDoorCagibitIn()
    {
        SoundManager.PlaySound("Door");
        SceneManager.LoadScene("Plateau2");
    }
}
