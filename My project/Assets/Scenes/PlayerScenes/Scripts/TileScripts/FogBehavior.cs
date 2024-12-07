using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogBehavior : MonoBehaviour
{
    private bool contact = false;
    [SerializeField] FogManagmer managmer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tile")
            contact = true;
        if (other.tag == "LOS" && contact && GameObject.FindGameObjectWithTag("FogManager").GetComponent<FogManagmer>().vanishing)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
