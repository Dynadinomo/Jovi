using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManagmer : MonoBehaviour
{
    [SerializeField] GameObject fogTiles;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector2 scale;
    private GameObject parent;
    public bool vanishing = true;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("FogManager");

        for (int i = 0; i < scale.x; i++)
        {
            for (int j = 0; j < scale.y; j++)
            {
                GameObject tile = Instantiate(fogTiles, parent.transform);
                Vector3 pos = new Vector3(tile.transform.localScale.x * j,0, tile.transform.localScale.y * i);
                tile.transform.position = pos + offset;
            }
        }
    }

    
}
