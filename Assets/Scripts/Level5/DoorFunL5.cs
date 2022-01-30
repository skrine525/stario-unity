using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFunL5 : MonoBehaviour
{
    public Wire wire;
    public float distance;
    public GameObject player, rightBorder, leftBorder, normalDoor;
    public LabGeneratorL5 lab;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wire.state > 0 && !active){
            active = true;
            rightBorder.SetActive(false);
            leftBorder.SetActive(false);
            normalDoor.SetActive(true);
            lab.activated = true;
        }

        if(active){
            float someDistance = Vector2.Distance(player.transform.position, transform.position);
            if(someDistance <= distance){
                transform.position += new Vector3(distance - someDistance, 0, 0);
            }
        }
    }
}
