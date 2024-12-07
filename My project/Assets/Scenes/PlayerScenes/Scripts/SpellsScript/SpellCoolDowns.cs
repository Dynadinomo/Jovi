using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCoolDowns : MonoBehaviour
{
    [SerializeField] public float fire = 60;
    [SerializeField] public float splash = 60;
    [SerializeField] public float peak = 60;
    [SerializeField] public float tp = 60;
    [SerializeField] public float ww = 60;
    [SerializeField] public float strike = 60;

    

    public float firetmr = 0;
    public float spltmr = 0;
    public float peaktmr = 0;
    public float tptmr = 0;
    public float wwtmr = 0;
    public float striketmr = 0;

    [SerializeField] Slider fslide;
    [SerializeField] Slider sslide;
    [SerializeField] Slider pslide;
    [SerializeField] Slider tslide;
    [SerializeField] Slider wslide;
    [SerializeField] Slider lslide;

    private void Start()
    {
        fslide.maxValue = fire;
        sslide.maxValue = splash;
        pslide.maxValue = peak;
        tslide.maxValue = tp;
        wslide.maxValue = ww;
        lslide.maxValue = strike;
    }

    private void invokedActivity()
    {
        if (firetmr > 0) {
            firetmr--;
            firetmr = Mathf.Clamp(firetmr, 0, fire);
        }
        if (spltmr > 0) {
            spltmr--;
            spltmr = Mathf.Clamp(spltmr, 0, splash);
        }
        if (peaktmr > 0) {
            peaktmr--;
            peaktmr = Mathf.Clamp(peaktmr, 0, peak);
        }
        if (tptmr > 0) {
            tptmr--;
            tptmr = Mathf.Clamp(tptmr, 0, tp);
        }
        if (wwtmr > 0) {
            wwtmr--;
            wwtmr = Mathf.Clamp(wwtmr, 0, ww);
        }
        if (striketmr > 0) {
            striketmr--;
            striketmr = Mathf.Clamp(striketmr, 0, strike);
        }

    }
    private void Update()
    {

        fslide.value = fire - firetmr;
        sslide.value = splash - spltmr;
        pslide.value = peak - peaktmr;
        tslide.value = tp - tptmr;
        wslide.value = ww - wwtmr;
        lslide.value = strike - striketmr;
    }
}
