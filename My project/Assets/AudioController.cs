using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource hit;
    public AudioSource crash;
    public AudioSource hurting;
    public AudioSource splash;
    public AudioSource heal;
    public AudioSource point;
    // Start is called before the first frame update
    public void playHit()
    {
        crash.Play();
    }
    public void playCrash()
    {
        hit.Play();
    }
    public void playHurting()
    {
        hurting.Play();
    }
    public void playSplash()
    {
        splash.Play();
    }
    public void playHeal()
    {
        heal.Play();
    }
    public void playPoint()
    {
        point.Play();
    }
    
}
