using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardChecker : MonoBehaviour
{
    [SerializeField] private Wire wire;
    [SerializeField] private GameObject cardui;
    public bool canTouch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Touch(){
        if(canTouch){
            wire.state = 1;
            cardui.SetActive(false);
        }
    }
}
