using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBurn : MonoBehaviour
{

    public float dmg = 1;
    public int timer = 300;
    public int cd = 30;
    public int hs;
    public bool active = false;
    private int cdRunner = 0;
    private NmeTakingDmg dmging;

    private void OnEnable()
    {
        cdRunner = cd;
        dmging = gameObject.GetComponent<NmeTakingDmg>();
    }
    private void invokedActivity()
    {

        if (timer <= 0)
        {
            Destroy(this);

        }

        if (cdRunner <= 0)
        {
            dmging.TakeDmg(dmg);
            cdRunner = cd;
        }
        cdRunner--;
        timer--;
    }
}
