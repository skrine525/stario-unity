using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public int state = 0;
    public Wire wire;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] stateSprites;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    }

    public bool Check(){
        return false;
    }

    public void Generate(){
        
    }
}
