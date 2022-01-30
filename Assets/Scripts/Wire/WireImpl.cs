using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireImpl : MonoBehaviour
{
    [SerializeField] private Wire input1, input2, output; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        output.state = (input1.state <= input2.state) ? 1 : 0;
    }
}
