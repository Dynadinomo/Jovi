using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class CastWhisperWall : MonoBehaviour
{
    public bool cast = false;
    private GameObject caster;
    private GameObject rReference;
    private GameObject reticle;
    private InputController ip;
    private Transform target;
    private Vector3 pos;
    private Vector2 oldDir = Vector2.zero;
    private CameraFollow cf;
    private Transform ec;
    private GameObject Wall;
    private int dist = 2;
    public void Casting(GameObject caster)
    {
        ip = GameObject.FindGameObjectWithTag("localOperator").GetComponent<InputController>();
        cf = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        rReference = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<PrefabManager>().rheticle;
        ec = GameObject.FindGameObjectWithTag("entityController").GetComponent<Transform>();
        Wall = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<PrefabManager>().WhisperWall;

        reticle = Instantiate(rReference);

        this.caster = caster;
        target = caster.transform;
        reticle.transform.position = target.position + Vector3.right * dist;

        cf.tr = reticle.transform;

        ip.mode = 1;
        cast = true;
    }

    // Update is called once per frame
    void Update()
    {
        cf.tr = target;
        Vector2 dir = ip.inputDir(false, true);
        if (dir != Vector2.zero)
        {
            pos = new Vector3(dir.x, 0, dir.y) * dist;
            pos += target.transform.position;
            reticle.transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            ip.mode = 0;
            cf.tr = caster.transform;

            GameObject gm = Instantiate(Wall);
            gm.transform.position = reticle.transform.position - new Vector3(0,1,0);
            gm.transform.parent = ec.transform;
            Vector3 rot = (caster.transform.position - reticle.transform.position);
            gm.transform.rotation = Quaternion.LookRotation(rot);

            Destroy(reticle);
            Destroy(this);
        }

    }
}
