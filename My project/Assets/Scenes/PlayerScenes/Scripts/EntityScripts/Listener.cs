using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    // public float activeClock = 0f;
    public static bool messagedCalled = false;
    // Start is called before the first frame update
    public void activityInvoked()
    {
        if (!messagedCalled)
        {
            messagedCalled = true;
            BroadcastMessage("invokedActivity");
            messagedCalled = false;
        }
    }
}
