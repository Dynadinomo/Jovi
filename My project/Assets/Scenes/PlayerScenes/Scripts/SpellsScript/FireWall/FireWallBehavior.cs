using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallBehavior : MonoBehaviour
{
    int healt = 200;
    private void OnEnable()
    {
        
    }

    private void invokedActivity()
    {
        healt--;
        if (healt < 0)
            Destroy(gameObject);
    }


}
