using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;

    private void awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.keyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.keyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Key key = collider.GetComponent<key>();
        if (key != null)
        {
            AddKey(key.GetKeyType())
            Destroy(key.gameObject);
        }
    }
}
