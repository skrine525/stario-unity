using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public bool robot = false;
    [SerializeField] private GameObject inputButtons, player;
    [SerializeField] private Sprite sprite;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(robot){
            inputButtons.SetActive(true);
            player.SetActive(true);
            animator.enabled = false;
            spriteRenderer.sprite = sprite;
            this.enabled = false;
        }
    }
}
