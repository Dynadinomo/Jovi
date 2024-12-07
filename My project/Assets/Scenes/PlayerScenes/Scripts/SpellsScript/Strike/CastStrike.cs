using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastStrike : MonoBehaviour
{
    public bool cast = false;
    private GameObject caster;
    private GameObject rReference;
    private GameObject reticle;
    private InputController ip;
    private Transform target;
    private Vector3 pos;
    private CameraFollow cf;
    private GameObject Bolt;
    private int dist = 5;
    public void Casting(GameObject caster)
    {
        ip = GameObject.FindGameObjectWithTag("localOperator").GetComponent<InputController>();
        cf = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        rReference = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<PrefabManager>().rheticle;
        Bolt = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<PrefabManager>().Bolt;

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

            GameObject gm = Instantiate(Bolt);
            gm.transform.position = reticle.transform.position - new Vector3(0, 1, 0);

            Destroy(reticle);
            Destroy(this);
        }

    }
}
