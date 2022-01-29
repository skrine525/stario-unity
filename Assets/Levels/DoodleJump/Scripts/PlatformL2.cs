using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformL2 : MonoBehaviour
{
    public float jumpForce;
    public bool destroyAfterJump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        Debug.Log("Hello!");
        Rigidbody2D rgbd = collider2D.GetComponent<Rigidbody2D>();
        rgbd.velocity = new Vector2(rgbd.velocity.x, 0);
        rgbd.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        if(destroyAfterJump){
            Rigidbody2D rgbd2 = gameObject.AddComponent<Rigidbody2D>();
            rgbd2.AddForce(new Vector2(0, -100), ForceMode2D.Impulse);
        }
            
    }
}
