using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearInLOS : MonoBehaviour
{

    BoxCollider bc;
    [SerializeField] SpriteRenderer sr;
    public float fade = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr.color = Color.clear;
    }

    private void FixedUpdate()
    {
        change(-500);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LOS")
        {
            change(850);
            print(other.transform.tag);
        }
    }

    private void change(float shift)
    {
        fade += shift*Time.deltaTime;
        fade = Mathf.Clamp(fade, 0, 255);
        sr.color = Color.Lerp(Color.clear, Color.green, fade/255);

    }
    
}
