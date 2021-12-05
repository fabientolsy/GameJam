using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip mainSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        mainSound = Resources.Load<AudioClip>("MainSound");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "MainSound":
                //audioSrc.PLayS
                break;
        }
    }
}
