using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireWall : MonoBehaviour
{
    public bool cast = false;
    private int pillars = 4;
    private GameObject caster;
    private GameObject rReference;
    private GameObject reticle;
    private InputController ip;
    private Transform target;
    private Vector3 pos;
    private Vector2 oldDir = Vector2.zero;
    private int buff = 0;
    private List<GameObject> flares = new List<GameObject>();
    private CameraFollow cf;
    private Transform ec;
    private GameObject fire;
    private AudioController ac;
    private int dist = 3;
    public void Casting(GameObject caster)
    {
        ip = GameObject.FindGameObjectWithTag("localOperator").GetComponent<InputController>();
        cf = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        rReference = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<PrefabManager>().rheticle;
        ec = GameObject.FindGameObjectWithTag("entityController").GetComponent<Transform>();
        fire = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<PrefabManager>().FirePillar;
        ac = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<AudioController>();

        reticle = Instantiate(rReference);

        this.caster = caster;
        target = caster.transform;
        reticle.transform.position = target.position + Vector3.right * dist;

        ip.mode = 1;
        cast = true;
    }



    public void FixedUpdate()
    {
        if (cast)
        {
            cf.tr = target;
            if (pillars != 0)
            {
                Vector2 dir = ip.inputDir(false, true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    flares.Add(reticle);
                    target = reticle.transform;
                    reticle = Instantiate(reticle);
                    pillars--;
                    if(dir.magnitude == 0)

                        reticle.transform.position = target.position + Vector3.right;
                }
                pos = new Vector3(dir.x, 0, dir.y);
                pos += target.transform.position;
                reticle.transform.position = pos;
                if (flares.Count == 0)
                {
                    pos = new Vector3(dir.x, 0, dir.y) * dist;
                    pos += target.transform.position;
                    reticle.transform.position = pos;
                }

            }
            else
            {
                cf.tr = caster.transform;
                Destroy(reticle);
                foreach(GameObject flare in flares)
                {
                    GameObject gm = Instantiate(fire);
                    gm.transform.position = flare.transform.position;
                    gm.transform.parent = ec.transform;
                    Destroy(flare);
                }
                ip.mode = 0;
                ac.playHit();

                Destroy(this);
            }
        }
    }
}
