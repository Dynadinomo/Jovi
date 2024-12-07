using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Starter()
    {

        SceneManager.LoadScene("SampleScene");
    }
    public void buttonQuit()
    {
        Application.Quit();
    }
}
