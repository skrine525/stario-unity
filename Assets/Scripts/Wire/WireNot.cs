using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireNot : MonoBehaviour
{
    [SerializeField] private Wire input, output;
    private int lastState;
    // Start is called before the first frame update
    void Start()
    {
        lastState = input.state;
        output.state = (input.state > 0) ? 0 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastState != input.state){
            lastState = input.state;
            output.state = (input.state > 0) ? 0 : 1;
        }
    }
}
