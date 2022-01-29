using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftPlat, rightPlat, player, platPrefab;
    public float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(leftPlat == null && Mathf.Abs(player.transform.position.x - transform.position.x - 6) <= distance){
            leftPlat = Instantiate(platPrefab) as GameObject;
            PlatGenerator platGenerator = leftPlat.GetComponent<PlatGenerator>();
            leftPlat.transform.position = new Vector3(transform.position.x - 6, transform.position.y, transform.position.z);
            platGenerator.rightPlat = gameObject;
            platGenerator.player = player;
            platGenerator.platPrefab = platPrefab;
            platGenerator.distance = distance;
        }
        else if(rightPlat == null && Mathf.Abs(player.transform.position.x - transform.position.x + 6) <= distance){
            rightPlat = Instantiate(platPrefab) as GameObject;
            rightPlat.transform.position = new Vector3(transform.position.x + 6, transform.position.y, transform.position.z);
            PlatGenerator platGenerator = rightPlat.GetComponent<PlatGenerator>();
            platGenerator.leftPlat = gameObject;
            platGenerator.player = player;
            platGenerator.platPrefab = platPrefab;
            platGenerator.distance = distance;
        }
        else if(Mathf.Abs(player.transform.position.x - transform.position.x) > distance * 1.5f){
            Destroy(gameObject);
        }
    }
}
