using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class music : MonoBehaviour
{
    public AudioSource Music;
    public Image onmusic;
    public Image musicoff;
    public bool mute = false;
   
    public void Onmusic()
    {
        if(mute)
        {
            mute= false;
            onmusic.enabled = true;
            musicoff.enabled = false;
            Music.Play();
        }
        else 
        {
            mute = true;
            onmusic.enabled = false;
            musicoff.enabled = true;
            Music.Stop();
        }
    }
    
}
