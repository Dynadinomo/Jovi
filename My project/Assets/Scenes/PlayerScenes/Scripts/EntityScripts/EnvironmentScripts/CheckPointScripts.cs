using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScripts : MonoBehaviour
{

    private CheckPointManager cpm;
    [SerializeField] private SpriteRenderer sr;
    private AudioController ac;
    // Start is called before the first frame update
    void Start()
    {
        ac = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<AudioController>();
        cpm = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<CheckPointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.GetComponent<AppearInLOS>() != null)
        {
            cpm.Checks.Add(gameObject);
            sr.color = Color.yellow;
            ac.playHeal();
            Destroy(gameObject.GetComponent<AppearInLOS>());
        }
    }
}
