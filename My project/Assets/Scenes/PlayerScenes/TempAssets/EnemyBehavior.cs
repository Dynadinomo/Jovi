using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    TxtBehavior txt;
    [SerializeField] int bInt = 0;
    [SerializeField] int dist = 1;
    private AudioController ac;
    float changeFactor = 0;
    Vector3 start;
    // Start is called before the first frame update
    void Awake()
    {
        start = transform.position;
        ac = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<AudioController>();
        txt = GameObject.Find("ScoreTXTObject").GetComponent<TxtBehavior>();
    }

    private void invokedActivity()
    {
        switch (bInt) { 
            case 1:
                behaveOne();
                break;
            case 2:
                behaveTwo();
                break;
            case 3:
                behaveThree();
                break;
            case 4:
                behaveFour();
                break;
            case 5: 
                behaveFive();   
                break;
            case 6:
                behaveSix();
                break;
            case 7:
                behaveSeven();
                break;
        
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            txt.Increment();
            ac.playPoint();
            Destroy(gameObject);
        }
    }


    private void behaveOne()
    {
        changeFactor += Time.deltaTime;
        //changeFactor = Mathf.PingPong(changeFactor, 1);
        transform.position = new Vector3(start.x, start.y, start.z + Mathf.Cos(changeFactor)*dist);
    }

    private void behaveTwo()
    {
        changeFactor += Time.deltaTime;
        //changeFactor = Mathf.PingPong(changeFactor, 1);
        transform.position = new Vector3(start.x + Mathf.Cos(changeFactor)*dist, start.y, start.z);
    }
    private void behaveThree()
    {
        changeFactor += Time.deltaTime;
        //changeFactor = Mathf.PingPong(changeFactor, 1);
        transform.position = new Vector3(start.x - Mathf.Cos(changeFactor)*dist, start.y, start.z);
    }
    private void behaveFour()
    {
        changeFactor += Time.deltaTime;
        //changeFactor = Mathf.PingPong(changeFactor, 1);
        transform.position = new Vector3(start.x - Mathf.Cos(changeFactor) * dist, start.y, start.z + Mathf.Sin(changeFactor) * dist);
    }
    private void behaveFive()
    {
        changeFactor += Time.deltaTime;
        //changeFactor = Mathf.PingPong(changeFactor, 1);
        transform.position = new Vector3(start.x - Mathf.Cos(changeFactor) * dist, start.y, start.z - Mathf.Sin(changeFactor) * dist);
    }
    private void behaveSix()
    {
        changeFactor += Time.deltaTime;
        //changeFactor = Mathf.PingPong(changeFactor, 1);
        transform.position = new Vector3(start.x + Mathf.Cos(changeFactor) * dist, start.y, start.z + Mathf.Sin(changeFactor) * dist);
    }
    private void behaveSeven()
    {
        changeFactor += Time.deltaTime;
        //changeFactor = Mathf.PingPong(changeFactor, 1);
        transform.position = new Vector3(start.x + Mathf.Cos(changeFactor) * dist, start.y, start.z - Mathf.Sin(changeFactor) * dist);
    }
}
