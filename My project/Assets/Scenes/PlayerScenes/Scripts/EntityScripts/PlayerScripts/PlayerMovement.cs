using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private InputController ip;
    private Listener lt;

    [SerializeField] float spd;
    [SerializeField] float[] st = new float[2];
    [SerializeField] float[] nd = new float[2];

    Vector3 push = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ip = GameObject.FindGameObjectWithTag("localOperator").GetComponent<InputController>();
        lt = GameObject.FindGameObjectWithTag("entityController").GetComponent<Listener>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ip.mode == 0)
        {
            push = movement() * Time.deltaTime * spd * 100;
            rb.velocity = new Vector3(push.x, rb.velocity.y, push.z);
        }
    }

    private Vector3 movement()
    {
        Vector3 inp = ip.inputDir(false,true);
        if (inp.magnitude != 0)
            lt.activityInvoked();
        return new Vector3(inp.x,0, inp.y);
    }
}
