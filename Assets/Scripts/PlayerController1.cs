using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool canMove = true;
    private int inputWidthLimit1, inputWidthLimit2, inputHeightLimit;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spriteLeft, spriteRight;
    private Rigidbody2D rgbd;
    private bool leftTouch, rightTouch = false;
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
                    else
                        MovableInputByTouch(touch);
                }
                    else
                        MovableInputByTouch(touch);
            }
            else
                MovableInputByTouch(touch);
        }
    }

    private void MovableInputByTouch(Touch touch){
        if(canMove){
            if(touch.position.y < inputHeightLimit){
                if(touch.position.x < inputWidthLimit2){
                    if(touch.phase != TouchPhase.Ended){
                        if(touch.position.x < inputWidthLimit1){
                            MoveLeft();
                        }
                        else if (touch.position.x > inputWidthLimit1 && touch.position.x < inputWidthLimit2){
                            MoveRight();
                        }
                    }
                    else if (touch.phase == TouchPhase.Ended){
                        MoveStop();
                    }
                }
                else if (touch.position.x > inputWidthLimit2){
                    if(touch.phase == TouchPhase.Began && !rightTouch){
                        rightTouch = true;
                        startRightTouchY = touch.position.y;
                    }
                    else if(touch.phase == TouchPhase.Ended && rightTouch){
                        rightTouch = false;
                        if(startRightTouchY - touch.position.y >= 200){
                            DoDown();
                        }
                        else{
                            DoJump();
                        }
                    }
                }
            }
        }
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

    void OnGUI(){
        float height = Screen.height - inputHeightLimit;
        GUI.Box(new Rect(inputWidthLimit1, height, 1, Screen.height), "*");
        GUI.Box(new Rect(inputWidthLimit2, height, 1, Screen.height), "*");
        GUI.Box(new Rect(0, height, Screen.width, 1), "*");
    }
}
