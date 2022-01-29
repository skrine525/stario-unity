using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableObject : MonoBehaviour
{
    public bool canTouch = true;
    public string callbackMethod;
    public float touchDistance;

    public void HandleSystemTouch(GameObject playerObject){
        if(canTouch && Vector2.Distance(playerObject.transform.position, transform.position) <= touchDistance)
            SendMessage(callbackMethod, playerObject);
    }
}
