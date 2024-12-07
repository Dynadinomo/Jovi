using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TxtBehavior : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = "Score: 0";
    }

    public void Increment() 
    { 
        score++;
        txt.text = "Score: "+ score.ToString();
    
    }
}
