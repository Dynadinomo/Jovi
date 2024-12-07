using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CastPeek : MonoBehaviour
{
    private InputController ip;
    private GameObject ret;
    private PlayerFieldOfView los;
    private FogManagmer Fm;
    private Transform ptr;
    private GameObject move;
    private CameraFollow cam;
    private Listener lt;
    private int stHP;
    private float spd = 5;
    private bool gone = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        ip = GameObject.FindGameObjectWithTag("localOperator").GetComponent<InputController>();
        ret = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<PrefabManager>().rheticle;
        los = GameObject.FindGameObjectWithTag("LOS").GetComponent<PlayerFieldOfView>();
        Fm = GameObject.FindGameObjectWithTag("FogManager").GetComponent<FogManagmer>();
        ptr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        lt = GameObject.FindGameObjectWithTag("entityController").GetComponent<Listener>();

        ip.mode = 1;
        stHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakingDamage>().health;
        Fm.vanishing = false;

        move = Instantiate(ret);
        move.transform.parent = GameObject.FindGameObjectWithTag("entityController").GetComponent<Transform>();
        move.transform.position = ptr.position;
        cam.tr = move.transform;

        los.tr = move.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gone)
        {
            bool interrupt = (stHP == GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakingDamage>().health);
            Vector2 dir = ip.inputDir(false, true);
            if (dir != Vector2.zero)
            {
                lt.activityInvoked();
                move.transform.position += new Vector3(dir.x, 0, dir.y) * spd * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Space) || !interrupt)
            {

                Abandon();
            }
        }
        else if(gone)
            Argue();
    }

    private void Abandon()
    {
        los.tr = ptr;
        cam.tr = ptr;

        Absolute();

    }
    private void Absolute()
    {


        Destroy(move);

        ip.mode = 0;
        gone = true;

    }
    private void Argue()
    {


        Fm.vanishing = true;
        Destroy(this);
    }

}
