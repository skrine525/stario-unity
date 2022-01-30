using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool canMove = true;
    private int inputWidthLimit1, inputWidthLimit2, inputHeightLimit;
    [SerializeField] private Button moveLeftButton, moveRightButton;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spriteLeft, spriteRight;
    private Rigidbody2D rgbd;
    private bool leftTouch, rightTouch = false, moveLeft = false, moveRight = false;
    private float startRightTouchY;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.freezeRotation = true;

        spriteRenderer = GetComponent<SpriteRenderer>();

        inputWidthLimit1 = Mathf.FloorToInt(Screen.width / 5);
        inputWidthLimit2 = inputWidthLimit1 * 2;
        inputHeightLimit = Mathf.FloorToInt(Screen.height / 3);

        GlobalData.playerController = this;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches){
            if(touch.phase == TouchPhase.Ended){
                Ray screenRay = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D screenHit = Physics2D.Raycast(screenRay.origin, screenRay.direction);
                if(screenHit){
                    TouchableObject touchableObject = screenHit.collider.GetComponent<TouchableObject>();
                    if(touchableObject != null){
                        touchableObject.HandleSystemTouch(gameObject);
                    }
                }
            }
        }

        if(moveLeft){
            MoveLeft();
        }
        else if (moveRight){
            MoveRight();
        }
    }

    public void StartMovingLeft(){
        moveLeft = true;
        moveRight = false;
    }

    public void StopMovingLeft(){
        moveLeft = false;
        MoveStop();
    }

    public void StartMovingRight(){
        moveRight = true;
        moveLeft = false;
    }

    public void StopMovingRight(){
        moveRight = false;
        MoveStop();
    }

    private void MoveLeft(){
        rgbd.velocity = new Vector2(-speed, rgbd.velocity.y);
        spriteRenderer.sprite = spriteLeft;
        transform.eulerAngles = new Vector2(-1, 0);
    }

    private void MoveRight(){
        rgbd.velocity = new Vector2(speed, rgbd.velocity.y);
        spriteRenderer.sprite = spriteRight;
        transform.eulerAngles = new Vector2(1, 0);
    }

    private void MoveStop(){
        rgbd.velocity = new Vector2(0, rgbd.velocity.y);
        transform.eulerAngles = new Vector2(0, 0);
    }

    private void DoJump(){
        Vector2 raycastPosition = new Vector2(transform.position.x, transform.position.y - transform.localScale.y);
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition, transform.TransformDirection(Vector2.down), 5);
        if(hit.collider != null && hit.distance < 0.1f){
            rgbd.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void DoDown(){
        Vector2 raycastPosition = new Vector2(transform.position.x, transform.position.y - transform.localScale.y);
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition, transform.TransformDirection(Vector2.down), 1);
        Debug.Log(hit.distance);
        if(hit.collider != null){
            PlatformController c = hit.transform.GetComponent<PlatformController>();
            Debug.Log(c == null);
            if(c != null){
                hit.collider.isTrigger = true;
            }
        }
    }
}
