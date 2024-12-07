using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector3> loader()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("TileParent");
        List<Vector3> child = new List<Vector3>();
        foreach (Transform t in obj.transform)
        {
            child.Add(t.position);
        }
        return child;
    }
}
