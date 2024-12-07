using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public int mode = 0;

    public Vector3 inputDir(bool down = false, bool normalized = false)
    {
        Vector3 dir = Vector2.zero;
        if (down)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                dir += new Vector3(0, 1);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                dir += new Vector3(-1, 0);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                dir += new Vector3(1, 0);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                dir += new Vector3(0, -1);
            }
            if(Input.GetKeyDown(KeyCode.Space))
                dir += new Vector3(0, 0,1);
            return dir;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            dir += new Vector3(0, 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            dir += new Vector3(-1, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            dir += new Vector3(1, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            dir += new Vector3(0, -1);
        }
        if (Input.GetKey(KeyCode.Space))
            dir += new Vector3(0, 0, 1);
        if (normalized == true)
        {

            float x = dir.y * -0.5f + dir.x * 0.5f;
            float y = dir.y * 0.5f + dir.x * 0.5f;
            dir.x = x; dir.y = y;
            return dir;
        }
        return dir;
    }
}
