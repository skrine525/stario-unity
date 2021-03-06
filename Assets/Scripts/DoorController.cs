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
    private AudioClip fx;
    private AudioSource audioSource;
    // Start is called before the first frame update

    void Awake(){
        fx = Resources.Load<AudioClip>("Audio/Lift");
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wire.state != 0 && canTouch == false){
            canTouch = true;
            animator.Play("DoorOpening");
            audioSource.PlayOneShot(fx);

        }
        else if(wire.state == 0 && canTouch == true){
            canTouch = false;
            animator.Play("DoorClosing");
            audioSource.PlayOneShot(fx);
        }
    }

    public void Touch(){
        if(canTouch)
            SceneManager.LoadScene(nextLevel);
    }
}
