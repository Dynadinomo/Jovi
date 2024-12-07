using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PrimerMenu : MonoBehaviour
{

    private InputController ip;
    private PlayerFieldOfView los;
    private FogManagmer Fm;
    private Camera cam;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject op;
    [SerializeField] GameObject help;
    [SerializeField] GameObject main;

    // Start is called before the first frame update
    void Start()
    {

        ip = GameObject.FindGameObjectWithTag("localOperator").GetComponent<InputController>();
        Fm = GameObject.FindGameObjectWithTag("FogManager").GetComponent<FogManagmer>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        pause();
    }

    public void pause()
    {
        cam.cullingMask = LayerMask.GetMask("Nothing");

        ip.mode = 1;
        Fm.vanishing = false;

        menu.SetActive(true);

        op.SetActive(false);
        help.SetActive(false);
        main.SetActive(false);
    }

    public void ButtonStart()
    {

        cam.cullingMask = ~0;
        Fm.vanishing = true;

        ip.mode = 0;

        menu.SetActive(false);
        main.SetActive(true);
    }
    public void ButtonOptions()
    {
        menu.SetActive(false) ;
        op.SetActive(true) ;

    }
    public void ButtonHelp()
    {
        menu.SetActive(false);
        help.SetActive(true);
    }
    public void buttonQuit()
    {
        Application.Quit();
    }
    public void resChange()
    {

    }
    public void optionsBack()
    {
        op.SetActive(false);
        menu.SetActive(true);
    }
    public void helpBack()
    {

        help.SetActive(false);
        menu.SetActive(true);
    }

}
