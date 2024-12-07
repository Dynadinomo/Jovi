using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearInLOS : MonoBehaviour
{

    BoxCollider bc;
    [SerializeField] SpriteRenderer sr;
    public float fade = 0;
    public Color color = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        sr.color = Color.clear;
    }

    private void invokedActivity()
    {
        change(-200);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LOS")
        {
            change(850);
        }
    }
    

    private void change(float shift)
    {
        fade += shift*Time.deltaTime;
        fade = Mathf.Clamp(fade, 0, 255);
        sr.color = Color.Lerp(Color.clear, color, fade/255);

        if(fade <= 0)
            sr.enabled = false;
        if(fade > 0)
            sr.enabled = true;

    }

    

}
