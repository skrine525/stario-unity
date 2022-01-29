using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCheckerSwitch : MonoBehaviour
{
    [SerializeField] private CardChecker cardChecker;
    [SerializeField] private GameObject cardui;
    public AudioClip beep;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Touch(){
        cardChecker.canTouch = true;
        Destroy(gameObject);
        cardui.SetActive(true);
    }
}
