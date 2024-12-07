using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogBehavior : MonoBehaviour
{
    private bool contact = false;
    private FogManagmer managmer;

    private void Start()
    {
        managmer = GameObject.FindGameObjectWithTag("FogManager").GetComponent<FogManagmer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tile")
            contact = true;
        if (other.tag == "LOS" && contact && managmer.vanishing)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
