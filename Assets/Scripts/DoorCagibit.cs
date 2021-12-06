using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCagibit : MonoBehaviour
{
    public void OpenDoorCagibit()
    {
        Debug.Log("momopipi");
        SoundManager.PlaySound("Door");
        SceneManager.LoadScene("CabaneJardin");
    }
}
