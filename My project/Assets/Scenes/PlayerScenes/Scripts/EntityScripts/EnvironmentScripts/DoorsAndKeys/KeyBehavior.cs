using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    public bool KeyGet = false;
    public SpriteRenderer sr;
    private AudioController ac;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ac = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<AudioController>();
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(gameObject.GetComponent<AppearInLOS>());
            //
            ac.playPoint();
            sr.enabled = false;
            KeyGet = true;
        }
    }
}
