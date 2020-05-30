using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, SwingSound, dashSound, walkSound;
    static AudioSource audioSrc;

    // Update is called once per frame
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("Sword 3");
        SwingSound = Resources.Load<AudioClip>("Sword Swish 1");
        dashSound = Resources.Load<AudioClip>("Sword Swish 2");
        walkSound = Resources.Load<AudioClip>("Grass1 25-Audio");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "playerhitted":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "swingsound":
                audioSrc.PlayOneShot(SwingSound);
                break;
            case "dashsound":
                audioSrc.PlayOneShot(dashSound);
                break;
            case "walksound":
                audioSrc.PlayOneShot(walkSound);
                break;
        }
    }
}
