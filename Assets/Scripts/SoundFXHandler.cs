using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXHandler : MonoBehaviour
{
    public AudioSource Src;
    public AudioClip exit, click;

    public void buttonClick()
    {
        Src.clip = click;
        Src.Play();
    }

    public void buttonExit()
    {
        Src.clip = exit; 
        Src.Play();
    }
}
