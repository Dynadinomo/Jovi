using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PathFind : MonoBehaviour
{
    private Transform ptr;
    [SerializeField] private Transform tr;
    private Vector3 target;
    private Ray ray;
    private RaycastHit hit;
    private bool Chase = false;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float spd;
    // Start is called before the first frame update
    void OnEnable()
    {
        ptr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = transform.position;
        //tr = GetComponent<Transform>();
        //rb = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Chase = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Chase = false;
        }
    }
    private void Update()
    {
        rb.velocity = Vector3.zero;
    }
    private void invokedActivity()
    {
        if (Chase == true)
        {

            float dist = Vector3.Distance(ptr.position, tr.position);
            ray = new Ray(tr.position, ptr.position-tr.position);
            if (!Physics.Raycast(ray, out hit, dist, LayerMask.GetMask("Terrain")))
            {
                target = ptr.position;

            }
        }
        Move();
    }
    
    private void Move()
    {
        rb.velocity = (target-tr.position).normalized*spd;
    }
}
