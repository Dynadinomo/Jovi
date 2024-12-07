using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{

    [SerializeField] Slider master;
    [SerializeField] Slider sfx;
    [SerializeField] Slider music;
    [SerializeField] AudioMixer am;

    // Update is called once per frame
    void Update()
    {
        
        MastVol = master.value;

        sfxVol = sfx.value;

        MusicVol = music.value;

    }
    protected float MastVol
    {
        get
        {
            float make;
            am.GetFloat("MasterVol", out make);
            return make;
        }
        set
        {
            am.SetFloat("MasterVol", value);
        }
    }
    protected float sfxVol
    {
        get
        {
            float make;
            am.GetFloat("SfxVol", out make);
            return make;
        }
        set
        {
            am.SetFloat("SfxVol", value);
        }
    }
    protected float MusicVol
    {
        get
        {
            float make;
            am.GetFloat("MusicVol", out make);
            return make;
        }
        set
        {
            am.SetFloat("MusicVol", value);
        }
    }
}
