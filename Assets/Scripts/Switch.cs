using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public int state = 0;
    public Wire wire;
    private AudioClip fx;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    [SerializeField] private Sprite[] stateSprites;
    // Start is called before the first frame update

    void Awake(){
        fx = Resources.Load<AudioClip>("Audio/Switch");
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer.sprite = stateSprites[state];
        wire.state = state;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Touch(){
        state = (state >= stateSprites.Length-1) ? 0 : (state+1);
        wire.state = state;
        spriteRenderer.sprite = stateSprites[state];
        audioSource.PlayOneShot(fx);
    }
}
