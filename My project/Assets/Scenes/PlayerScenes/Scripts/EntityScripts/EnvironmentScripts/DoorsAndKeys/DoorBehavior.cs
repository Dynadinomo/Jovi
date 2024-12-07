using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] private List<GameObject> keys = new List<GameObject>();
    [SerializeField] private Sprite nd;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private AppearInLOS aol;
    private AudioController ac;
    private TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GameObject.FindGameObjectWithTag("DoorTxt").GetComponent<TextMeshProUGUI>();
        ac = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<AudioController>();
        txt.text = "";
        foreach (GameObject key in keys)
        {
            key.GetComponent<AppearInLOS>().color = aol.color;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int i = 0;
            foreach (GameObject key in keys)
            {
                if (key.GetComponent<KeyBehavior>().KeyGet)
                {
                    i++;
                }
            }

            if (i == keys.Count)
                Open();
            else
            {
                txt.color = aol.color;
                txt.text = i.ToString() + "/" + keys.Count.ToString();
            }

        }
    }
    private void invokedActivity()
    {
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            txt.text = "";

        }
    }

    private void Open()
    {
        sr.sprite = nd;
        ac.playHit();
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
