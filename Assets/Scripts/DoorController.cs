using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private bool canTouch = false;
    public Wire wire;
    public string nextLevel;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wire.state != 0 && canTouch == false){
            canTouch = true;
            animator.Play("DoorOpening");

        }
        else if(wire.state == 0 && canTouch == true){
            canTouch = false;
            animator.Play("DoorClosing");
        }
    }

    public void Touch(){
        if(canTouch)
            SceneManager.LoadScene(nextLevel);
    }
}
