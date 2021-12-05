using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip doorSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        doorSound = Resources.Load<AudioClip>("Door");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Door":
                audioSrc.PlayOneShot(doorSound);
                break;
        }
    }
}
