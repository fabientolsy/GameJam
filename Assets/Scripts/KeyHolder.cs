using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;
    private List<Key.KeyType> keyList;

    private void awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("jsuis rentree");
        Key key = collider.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
            Debug.Log("G la cleeeee");
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            Debug.Log("");
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                Debug.Log("JE ME TP");
                keyDoor.OpenDoor();
            }
        }

        DoorCagibitIn doorCagibitin = collider.gameObject.GetComponent<DoorCagibitIn>();
        DoorCagibit doorCagibit = collider.gameObject.GetComponent<DoorCagibit>();
        DoorRoom doorRoom = collider.gameObject.GetComponent<DoorRoom>();
    }
}
