using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardChecker : MonoBehaviour
{
    [SerializeField] private Wire wire;
    [SerializeField] private GameObject cardui;
    private AudioClip beep;
    private AudioSource audioSource;
    public bool canTouch = false;
    // Start is called before the first frame update

    void Awake(){
        beep = Resources.Load<AudioClip>("Audio/Beep");
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Touch(){
        if(canTouch){
            wire.state = 1;
            cardui.SetActive(false);
            audioSource.PlayOneShot(beep);
        }
    }
}
