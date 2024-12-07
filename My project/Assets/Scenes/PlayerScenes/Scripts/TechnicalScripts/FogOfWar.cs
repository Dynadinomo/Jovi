using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FogOfWar : MonoBehaviour
{
    [SerializeField] Texture2D txtr;
    [SerializeField] Transform cam;
    [SerializeField] Transform p;
    [SerializeField] int r = 50;
    SpriteRenderer spriteRenderer;

    Ray ray;

    private Vector2 wScale;
    private Vector2 pScale;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10000; i++)
        {
            for (int j = 0; j < 10000; j++)
            {
                txtr.SetPixel(i, j, Color.black);
            }
        }

        txtr.Apply();
    }

    // Update is called once per frame
    void invokedActivity()
    {
        Vector3 dir = p.localPosition-cam.localPosition;
        float dist = Vector3.Distance(cam.localPosition, p.localPosition);
        ray = new Ray(cam.position,dir.normalized*dist);

        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            Vector2 pix = new Vector2(hit.textureCoord.x * txtr.width, hit.textureCoord.y * txtr.height);

            for(int i = 0; i < r; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    txtr.SetPixel(Mathf.RoundToInt(pix.x) - (r/2) + i, Mathf.RoundToInt(pix.y)-(r/2)+j, Color.clear);
                }
            }
            txtr.Apply();
        }

        Debug.DrawRay(cam.position, dir.normalized * dist);
    }
}
