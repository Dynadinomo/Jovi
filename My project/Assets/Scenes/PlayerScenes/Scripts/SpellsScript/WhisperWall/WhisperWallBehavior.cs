using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhisperWallBehavior : MonoBehaviour
{
    [SerializeField] int hp = 100;
    // Start is called before the first frame update
    private void invokedActivity()
    {
        if (hp <= 0)
            Destroy(gameObject);
        hp--;
    }
}
