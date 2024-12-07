using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMenuController : MonoBehaviour
{

    [SerializeField] private GameObject Caster;
    private SpellList SpellList;
    private InputController ip;
    private PrimerMenu pm;
    private SpellCoolDowns spd;

    // Start is called before the first frame update
    void Start()
    {
        SpellList = GameObject.FindGameObjectWithTag("entityController").GetComponent<SpellList>();
        ip = GameObject.FindGameObjectWithTag("localOperator").GetComponent<InputController>();

        pm = GameObject.FindGameObjectWithTag("PauseObject").GetComponent<PrimerMenu>();
        spd = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellCoolDowns>();

    }

    // Update is called once per frame
    void Update()
    {

        if (ip.mode == 0 && Input.GetKeyDown(KeyCode.Alpha1) && spd.firetmr <= 0)
        {
            spd.firetmr = spd.fire;
            SpellList.CastSpell(0, Caster);
        }
        if (ip.mode == 0 && Input.GetKeyDown(KeyCode.Alpha2) && spd.spltmr <= 0)
        {
            spd.spltmr = spd.splash;
            SpellList.CastSpell(1, Caster);
        }
        if (ip.mode == 0 && Input.GetKeyDown(KeyCode.Alpha3) && spd.peaktmr <= 0)
        {
            spd.peaktmr = spd.splash;
            SpellList.CastSpell(2, Caster);
        }
        if (ip.mode == 0 && Input.GetKeyDown(KeyCode.Alpha4) && spd.tptmr <= 0)
        {
            spd.tptmr = spd.tp;
            SpellList.CastSpell(3, Caster);
        }
        if (ip.mode == 0 && Input.GetKeyDown(KeyCode.Alpha5) && spd.wwtmr <= 0)
        {
            spd.wwtmr = spd.ww;
            SpellList.CastSpell(4, Caster);
        }
        if (ip.mode == 0 && Input.GetKeyDown(KeyCode.Alpha6) && spd.striketmr <= 0)
        {
            SpellList.CastSpell(5, Caster);
            spd.striketmr = spd.strike;
        }
        if (ip.mode == 0 && Input.GetKeyDown(KeyCode.H))
        {
            pm.pause();
        }
    }
}
