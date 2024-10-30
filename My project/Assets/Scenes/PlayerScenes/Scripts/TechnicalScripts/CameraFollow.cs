using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform tr;
    [SerializeField] Vector3 offset;

    [Header("Smooth Damp Variables")]
    [SerializeField] float spd = 5;
    [SerializeField] float time = 1;
    float timer = 0;

    private Vector3 v = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, tr.position + offset,ref v, time, spd, Time.deltaTime);
        timer += Time.deltaTime;
    }
}
