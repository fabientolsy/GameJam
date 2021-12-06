using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoor : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    [SerializeField] private Key.KeyType keyType;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }
    
    public void OpenDoor()
    {
        playerStorage.initialValue = playerPosition;
        SoundManager.PlaySound("Door");
        SceneManager.LoadScene(sceneToLoad);
    }
}
