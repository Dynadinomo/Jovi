using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashBehavior : MonoBehaviour
{
    [SerializeField] int state = 0;
    [SerializeField] float dmg = 2;
    [SerializeField] int power = 2;
    private AudioController ac;
    private List<GameObject> aoe = new List<GameObject>();
    // Start is called before the first frame update
    private void OnEnable()
    {
        Animator animation = GetComponent<Animator>();
        ac = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<AudioController>();
        animation.Play("Grow");
        ac.playSplash();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NmeTakingDmg>())
        {
            NmeTakingDmg nme = other.gameObject.GetComponent<NmeTakingDmg>();
            Rigidbody rg = other.gameObject.GetComponent<Rigidbody>();
            Transform tr = other.gameObject.GetComponent<Transform>();
            Vector3 oppose = (tr.position - gameObject.transform.parent.transform.position).normalized;
            print("state");
            if (state <= 1)
            {
                if (!aoe.Contains(other.gameObject))
                {
                    print("gothere");
                    nme.TakeDmg(dmg);
                    aoe.Add(other.gameObject);
                }
                oppose *= power * 2;
                rg.velocity = new Vector3(oppose.x, rg.velocity.y, oppose.z);

            }
            else if (state <= 3) {

                oppose *= power;
                rg.velocity = new Vector3(oppose.x, rg.velocity.y, oppose.z) * 1;
            }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<NmeTakingDmg>())
        {
            NmeTakingDmg nme = other.gameObject.GetComponent<NmeTakingDmg>();
            Rigidbody rg = other.gameObject.GetComponent<Rigidbody>();
            Transform tr = other.gameObject.GetComponent<Transform>();
            Vector3 oppose = (tr.position - gameObject.transform.parent.transform.position).normalized;

            if (state <= 1)
            {
                if (!aoe.Contains(other.gameObject))
                {
                    print("gothere");
                    nme.TakeDmg(dmg);
                    aoe.Add(other.gameObject);
                }
                oppose *= power * 2;
                rg.velocity = new Vector3(oppose.x, rg.velocity.y, oppose.z);

            }
            else if (state <= 3)
            {

                oppose *= power;
                rg.velocity = new Vector3(oppose.x, rg.velocity.y, oppose.z) * 1;
            }
        }
    }
    private void Update()
    {
        if (state == 3)
        {
            aoe.Clear();
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}

