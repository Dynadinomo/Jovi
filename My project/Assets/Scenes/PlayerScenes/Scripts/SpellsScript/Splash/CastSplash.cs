using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSplash : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject splash;
    private void OnEnable()
    {

        splash = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<PrefabManager>().Splash;
    }

    public void Casting(GameObject Caster)
    {
        GameObject sp = Instantiate(splash);
        sp.transform.position = Caster.transform.position;
    }
    public void Kill()
    {
        Destroy(this);
    }
}
