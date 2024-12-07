using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFieldOfView : MonoBehaviour
{
    [SerializeField] Vector3 eyesOffset = new Vector3(0, 0, 0);


    [Header("LineOfSiteProperties")]
    [SerializeField] int rayCount = 4;
    [SerializeField] float dist = 3;

    [SerializeField] public Transform tr;


    Vector3[] v;
    Vector2[] u;
    int[] part;
    Mesh m;
    MeshFilter mf;
    MeshCollider Mc;


    // Start is called before the first frame update
    void Start()
    {
        m = new Mesh();
        mf = GetComponent<MeshFilter>();
        mf.mesh = m;
        Mc = GetComponent<MeshCollider>();
        Mc.sharedMesh = m;
        

    }

    private Vector3 Point(float angle)
    {
        float toRet = angle * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(toRet),0, Mathf.Sin(toRet));
    }

    // Update is called once per frame
    void Update()
    {

        v = new Vector3[rayCount+2];
        u = new Vector2[v.Length];
        part = new int[v.Length * 3];

        v[0] = tr.position + eyesOffset;

        for (int i = 0; i <= rayCount; i++)
        {
            float angle = (360 / rayCount) * -i;
            Vector3 point = Vector3.zero;
            Ray ray = new Ray(v[0], Point(angle) * dist);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit ,dist,LayerMask.GetMask("Terrain")))
            {

                point = hit.point;

            }
            else
            {
                point = v[0] + (Point(angle) * dist);
            }

            v[i + 1] = point;
            if (i > 0)
            {
                part[3 * i] = 0;
                part[(3 * i) + 1] = i;
                part[(3 * i) + 2] = i+1;
            }

        }


        m.vertices = v;
        m.uv = u;
        m.triangles = part;

        Mc.sharedMesh = m;
        //mf.sharedMesh = m;
        mf.sharedMesh.RecalculateBounds();
        mf.sharedMesh.RecalculateNormals();

    }
}
