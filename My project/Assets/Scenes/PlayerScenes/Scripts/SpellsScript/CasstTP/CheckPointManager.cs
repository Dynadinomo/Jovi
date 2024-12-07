using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> Checks = new List<GameObject>();

    private void Start()
    {
        Checks.Add(GameObject.FindGameObjectWithTag("Player"));
    }

    public void AddCheck(GameObject go)
    {
        Checks.Add(go);
    }
}
