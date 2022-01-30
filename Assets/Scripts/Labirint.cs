using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labirint : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private LabirintObjectController labirintObjectController;
    [SerializeField] private GameObject labirint, textUI, inputButtons;
    private bool active = false;
    // Start is called before the first frame update
    void Starts()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Touch(){
        if(!active){
            active = true;
            playerController.canMove = false;
            labirint.transform.position = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)).origin;
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
