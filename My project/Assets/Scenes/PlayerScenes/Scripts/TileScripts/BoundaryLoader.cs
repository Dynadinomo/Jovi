using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BoundaryLoader : MonoBehaviour
{
    [SerializeField] GameObject child;
    public void boundaryCalulator(List<Vector3> tpos)
    {
        Dictionary<float,List<Vector3>> xpos = new Dictionary<float, List<Vector3>>();
        Dictionary<float, List<Vector3>> zpos = new Dictionary<float, List<Vector3>>();
        Vector3[] a = new Vector3[3];
        int d = 0;


        foreach (var t in tpos) {
            a = calculateCollision(t);
            for (int i = 0; i < 4; i++) {

                float x = a[i].x; float y = t.y; float z = a[i].z; 
                Vector3 b = new Vector3(x, y, z);
                print(!tpos.Contains(b));

                if (!tpos.Contains(b))
                {
                    Vector3 c = new Vector3(x, 0, z);

                    if (!xpos.ContainsKey(x))
                    {
                        xpos.Add(x,new List<Vector3>());
                    }
                    
                    if (!zpos.ContainsKey(z))
                    {
                        zpos.Add(z, new List<Vector3>());
                    }

                    d = boundaryIndexQuery(xpos[x], c, new Vector3(0,0,1));
                    xpos[x].Insert(d,c);

                    d = boundaryIndexQuery(zpos[z], c, new Vector3(1, 0, 0));
                    zpos[z].Insert(d, c);
                }
            }
        }

        placeBounds(xpos);
        
        
    }

    private void placeBounds(Dictionary<float, List<Vector3>> x)
    {
        GameObject parent = GameObject.FindGameObjectWithTag("BoundaryParent");

        foreach(float a in x.Keys)
        {
            foreach(Vector3 t in x[a])
            {
                GameObject bound = Instantiate(child);
                bound.transform.position = t;
                bound.transform.parent = parent.transform;
            }
        }
    }

    private int boundaryIndexQuery(List<Vector3> check, Vector3 insert, Vector3 prime)
    {
        if(check.Count == 0)
            return 0;

        float toCheck = primer(insert,prime);
        for (int i = 0; i < check.Count; i++) { 
            float toVer = primer(check[i],prime);
            if (toVer < toCheck) 
                return i;
        }
        return 0;
    }

    private float primer(Vector3 col, Vector3 prime) {
        Vector3 ret = new Vector3(col.x * prime.x, col.y * prime.y, col.z * prime.z);
        float a = ret.x + ret.y + ret.z;
        return a;
    }


    private Vector3[] calculateCollision(Vector3 pos)
    {
        Vector3[] colliders = new Vector3[4];
        //up
        colliders[0] = pos + new Vector3(-1,pos.y,0);
        //down
        colliders[1] = pos + new Vector3(1, pos.y, 0);
        //left
        colliders[2] = pos + new Vector3(0, pos.y, 1);
        //right
        colliders[3] = pos + new Vector3(0, pos.y, -1);
        return colliders;
    }
}
