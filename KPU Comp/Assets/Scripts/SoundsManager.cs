using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static AudioClip button, coblos, walk;
    static AudioSource audioSrc;
   // private VolumeManager volmanager;

    void Start()
    {
        button = Resources.Load<AudioClip>("Button 3");
        coblos = Resources.Load<AudioClip>("Coblos");
        walk = Resources.Load<AudioClip>("Footsep");

        //volmanager = FindObjectOfType(typeof(VolumeManager)) as VolumeManager;

        audioSrc = GetComponent<AudioSource> ();
    }

    public static void PlaySound (string clip)
    {
        switch (clip) 
        {
            case "Button 3":
                audioSrc.PlayOneShot(button);
                break;
            case "Coblos":
                audioSrc.PlayOneShot(coblos);
                break;
            case "Footstep":
                audioSrc.PlayOneShot(walk);
                break;
        }
    }
}