using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamager : MonoBehaviour
{
    public float dmg = 1;
    public float hitStun = 60;
    [SerializeField] LayerMask lyr;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<NmeTakingDmg>())
        {
            if(!other.GetComponent<StatusBurn>())
                other.gameObject.AddComponent<StatusBurn>();
            StatusBurn burn = other.GetComponent<StatusBurn>();
            burn.dmg = 1;
            burn.cd = 1;
            burn.timer = 300;
            burn.hs = 0;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<NmeTakingDmg>())
        {
            if (!other.GetComponent<StatusBurn>())
                other.gameObject.AddComponent<StatusBurn>();
            StatusBurn burn = other.GetComponent<StatusBurn>();
            burn.dmg = 1;
            burn.cd = 60;
            burn.timer = 300;
            burn.hs = 0;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<NmeTakingDmg>())
        {
            if (!other.GetComponent<StatusBurn>())
                other.gameObject.AddComponent<StatusBurn>();
            StatusBurn burn = other.GetComponent<StatusBurn>();
            burn.dmg = 1;
            burn.cd = 120;
            burn.timer = 300;

        }
    }
}
