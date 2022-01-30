using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabirintTrigger : MonoBehaviour
{
    [SerializeField] private GameObject labirintGameObject, inputButtons;
    [SerializeField] private Labirint labirint;
    [SerializeField] private PlayerController player;
    [SerializeField] private Wire wire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        wire.state = 1;
        inputButtons.SetActive(true);
        player.canMove = true;
        labirint.enabled = false;
        labirintGameObject.SetActive(false);
    }
}
