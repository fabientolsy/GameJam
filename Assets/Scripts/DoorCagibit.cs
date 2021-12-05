using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCagibit : MonoBehaviour
{
    public void OpenDoorCagibit()
    {
        SoundManager.PlaySound("Door");
        SceneManager.LoadScene("CabaneJardin");
    }
}
