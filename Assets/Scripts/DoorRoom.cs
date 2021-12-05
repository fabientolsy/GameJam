using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorRoom : MonoBehaviour
{
    public void OpenDoorRoom()
    {
        SoundManager.PlaySound("Door");
        SceneManager.LoadScene("Plateau1");
    }
}
