using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labirint : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private LabirintObjectController labirintObjectController;
    [SerializeField] private GameObject labirint, textUI, inputButtons;
    [SerializeField] private Wire wire;
    [SerializeField] private Sprite enabledSprite, disabledSprite;
    private TouchableObject touchableObject;
    private SpriteRenderer spriteRenderer;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        touchableObject = GetComponent<TouchableObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wire.state == 0 && touchableObject.canTouch){
            touchableObject.canTouch = false;
            spriteRenderer.sprite = disabledSprite;
        }
        else if(wire.state > 0 && !touchableObject.canTouch){
            touchableObject.canTouch = true;
            spriteRenderer.sprite = enabledSprite;
        }
    }

    public void Touch(){
        if(!active){
            active = true;
            playerController.canMove = false;
            labirint.transform.position = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)).origin;
            labirint.transform.position += new Vector3(0, 0, 5);
            labirint.SetActive(true);
            inputButtons.SetActive(false);
            StartCoroutine(ShowHint());
        }
    }

    private IEnumerator ShowHint(){
        textUI.SetActive(true);
        yield return new WaitForSeconds(4f);
        textUI.SetActive(false);
        labirintObjectController.canMove = true;
    }
}
