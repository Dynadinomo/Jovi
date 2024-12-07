using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellList : MonoBehaviour
{
    private GameObject SpellParent;
    [SerializeField] public GameObject Rhetical;
    private void Start()
    {
        SpellParent = new GameObject();
        SpellParent.transform.parent = GameObject.FindGameObjectWithTag("entityController").transform;
        SpellParent.name = "SpellParentObject";
    }
    public void CastSpell(int index, GameObject Caster)
    {
        switch (index) { 
            case 0:
                SpellParent.AddComponent<CastFireWall>(); 
                CastFireWall spell = SpellParent.GetComponent<CastFireWall>();
                spell.Casting(Caster);
                break;

            case 1:
                SpellParent.AddComponent<CastSplash>();
                CastSplash spell1 = SpellParent.GetComponent<CastSplash>();
                spell1.Casting(Caster);
                spell1.Kill();
                break;

            case 2:
                SpellParent.AddComponent<CastPeek>();
                CastPeek spell2 = SpellParent.GetComponent<CastPeek>();
                break;

            case 3:
                SpellParent.AddComponent<CastTp>();
                CastTp spell3 = SpellParent.GetComponent<CastTp>();
                break;

            case 4:
                SpellParent.AddComponent<CastWhisperWall>();
                CastWhisperWall spell4 = SpellParent.GetComponent<CastWhisperWall>();
                spell4.Casting(Caster);
                break;

            case 5:
                SpellParent.AddComponent<CastStrike>();
                CastStrike spell5 = SpellParent.GetComponent<CastStrike>();
                spell5.Casting(Caster);
                break;
        }
    }
}
