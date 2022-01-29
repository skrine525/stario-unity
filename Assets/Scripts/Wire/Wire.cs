using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public Wire connection;
    public int state = 0;
    private int lastState = -1;
    [SerializeField] private Sprite enabledSprite, disabledSprite;
    private SpriteRenderer spriteRenderer;
    #pragma warning restore format
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = disabledSprite;
        ChangeSpite();
        lastState = state;
    }

    // Update is called once per frame
    void Update()
    {
        if(connection != null)
            connection.state = state;
        
        if(lastState != state){
            lastState = state;
            ChangeSpite();
        }
    }

    private void ChangeSpite(){
        if(state > 0)
            spriteRenderer.sprite = enabledSprite;
        else
            spriteRenderer.sprite = disabledSprite;
    }
}
