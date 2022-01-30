using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabirintObjectController : MonoBehaviour
{
    public bool canMove = false;
    [SerializeField] private GameObject spawn;
    [SerializeField] private float speed;
    private Rigidbody2D rgbd;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.freezeRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
            rgbd.velocity = new Vector3(Input.acceleration.x*speed, Input.acceleration.y*speed, 0) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision){
        transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, transform.position.z);
    }
}
