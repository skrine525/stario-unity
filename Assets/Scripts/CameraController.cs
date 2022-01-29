using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float minXPosition, maxXPosition;
    // Start is called before the first frame update
    void Start()
    {
        MoveToPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate(){
        MoveToPlayer();
    }

    private void MoveToPlayer(){
        if(minXPosition != 0 && player.position.x < minXPosition)
            transform.position = new Vector3(minXPosition, transform.position.y, transform.position.z);
        else if (maxXPosition != 0 && player.position.x > maxXPosition)
            transform.position = new Vector3(maxXPosition, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
