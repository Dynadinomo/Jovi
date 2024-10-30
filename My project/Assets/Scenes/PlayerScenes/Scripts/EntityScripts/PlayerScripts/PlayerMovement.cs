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
        push = movement() * Time.deltaTime * spd *100;
        rb.velocity = new Vector3(push.x, rb.velocity.y, push.z);
    }

    private Vector3 movement()
    {
        Vector2 inp = ip.inputDir();
        float x = inp.y*st[0] + inp.x*st[1];
        float y = inp.y*nd[0] + inp.x*nd[1];
        if (x != 0 || y != 0)
            lt.invokeActivity();
        return new Vector3(x,0, y);
    }
}
