using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireAnd : MonoBehaviour
{
    [SerializeField] private Wire input1, input2, output;
    private int lastState;
    // Start is called before the first frame update
    void Start()
    {
        output.state = ((input1.state > 0) && (input2.state > 0)) ? 1 : 0;
        lastState = output.state;
    }

    // Update is called once per frame
    void Update()
    {
        if(((input1.state > 0) && (input2.state > 0)) && lastState == 0){
            output.state = 1;
            lastState = output.state;
        }
        else if(((input1.state <= 0) || (input2.state <= 0)) && lastState == 1){
            output.state = 0;
            lastState = output.state;
        }
    }
}
