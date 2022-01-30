using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabGeneratorL5 : MonoBehaviour
{
    public GameObject player, labPrefab;
    public bool activated = true;
    private bool generated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activated && !generated && transform.position.x - player.transform.position.x < 20){
            GameObject newLab = Instantiate(labPrefab) as GameObject;
            LabGeneratorL5 newGen = newLab.GetComponent<LabGeneratorL5>();
            newGen.player = player;
            newLab.transform.parent = transform.parent;
            newLab.transform.position = transform.position + new Vector3(28, 0, 0);
            generated = true;
        }
    }
}
