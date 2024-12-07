using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeBehavior : MonoBehaviour
{
    [SerializeField] int state = 0;
    [SerializeField] float dmg = 2;
    private AudioController ac;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Animator animation = GetComponent<Animator>();
        ac = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<AudioController>();
        animation.Play("Strike");
        ac.playCrash();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NmeTakingDmg>())
        {
            NmeTakingDmg nme = other.gameObject.GetComponent<NmeTakingDmg>();
            nme.TakeDmg(dmg);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(state > 1)
            Destroy(gameObject.transform.parent.gameObject);
    }
}
