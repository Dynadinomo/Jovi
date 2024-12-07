using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NmeTakingDmg : MonoBehaviour
{

    public float HitStun = 0;
    [SerializeField] float health = 10;
    [SerializeField] Animator anim;
    [SerializeField] private bool takeanim = false;
    [SerializeField] private bool ani = false;
    private AudioController ac;

    // Start is called before the first frame update
    void Start()
    {

        ac = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<AudioController>();
    }

    
    public void TakeDmg(float dmg)
    {
        health -= dmg;
        if (!takeanim)
        {
            if(!ani)
                anim.Play("Hit");
            ac.playHurting();
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void invokedActivity()
    {
        if (HitStun > 0)
            HitStun--;
    }
}
