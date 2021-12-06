using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorRoom : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    public void OpenDoorRoom()
    {
        playerStorage.initialValue = playerPosition;
        SoundManager.PlaySound("Door");
        SceneManager.LoadScene(sceneToLoad);
    }
}
