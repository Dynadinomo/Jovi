using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastTp : MonoBehaviour
{
    private CheckPointManager cpm;
    private GameObject ply;
    private InputController ip;
    private List<GameObject> plyList;
    private GameObject ret;
    private GameObject move;
    private CameraFollow cam;
    private GameObject go;

    private float index = 0;

    private void OnEnable()
    {

        cpm = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<CheckPointManager>();
        ip = GameObject.FindGameObjectWithTag("localOperator").GetComponent<InputController>();
        ply = GameObject.FindGameObjectWithTag("Player");
        ret = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<PrefabManager>().rheticle;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();


        ip.mode = 1;


        plyList = cpm.Checks;
        move = Instantiate(ret);

        cam.tr = move.transform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D))
        {
            index++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A))
        {
            index--;
        }

        index = Mathf.Repeat(index, plyList.Count);

        go = plyList[((int)index)];

        move.transform.position = go.transform.position + new Vector3(0,1,0);

        if (Input.GetKeyDown(KeyCode.Space))
            Abandon();

    }

    private void Abandon()
    {
        ply.transform.position = go.transform.position;
        cam.tr = ply.transform;
        ip.mode = 0;
        Destroy(move);
        Destroy(this);
    }
}
