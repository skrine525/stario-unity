using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerStartMoveLeft(){
        if(GlobalData.playerController != null)
            GlobalData.playerController.StartMovingLeft();
    }

    public void PlayerStopMoveLeft(){
        if(GlobalData.playerController != null)
            GlobalData.playerController.StopMovingLeft();
    }

    public void PlayerStartMoveRight(){
        if(GlobalData.playerController != null)
            GlobalData.playerController.StartMovingRight();
    }

    public void PlayerStopMoveRight(){
        if(GlobalData.playerController != null)
            GlobalData.playerController.StopMovingRight();
    }

    public void GoToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
