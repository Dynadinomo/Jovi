using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilerManager : MonoBehaviour
{
    private TileLoader tileLoader;
    private BoundaryLoader boundariesLoader;
    // Start is called before the first frame update
    void Start()
    {

        print("done");
        tileLoader = GetComponent<TileLoader>();
        boundariesLoader = GetComponent<BoundaryLoader>();
        List<Vector3> tPos = tileLoader.loader();
        boundariesLoader.boundaryCalulator(tPos);

        GameObject controller = new GameObject();
        controller.tag = "TileController";
        controller.name = "TController";
        controller.AddComponent<TileController>();
        
        TileController tc = controller.GetComponent<TileController>();
        tc.tilePos = tPos;

        Destroy(gameObject);

        print("done");

    }

}
