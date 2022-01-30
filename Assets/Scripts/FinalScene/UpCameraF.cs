using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpCameraF : MonoBehaviour
{
    public Wire wire;
    public float speed;
    private Vector3 positionB;
    private bool hidden = false;
    [SerializeField] private GameObject inputButtons;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(wire.state > 0){
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 13.7f, -10), speed);
            if(!hidden){
                hidden = true;
                inputButtons.SetActive(false);
            }
        }
    }
}
