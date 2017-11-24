using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour {

    // Pause System //

    public bool pause = false;
    public Transform player;
    public GameObject pauseObj,continueButton;

    //public GameObject audioObj;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Pause"))
        {
            PauseMode();
        }
    }

    public void PauseMode()
    {
        if (!pause && player != null)
        {
            Time.timeScale = 0;
            if(player != null)
            {
                player.GetComponent<PlayerMoves>().enabled = false;
            }
            pauseObj.SetActive(true);
            pause = true;

            if(Input.GetJoystickNames()[0] != "")
            {
                EventSystem.current.SetSelectedGameObject(continueButton);
            }
            else
            {
                Cursor.visible = true;
            }
           
            
        }
        else if (pause && player != null)
        {
            
            Time.timeScale = 1;
            player.GetComponent<PlayerMoves>().enabled = true;
            if (Input.GetJoystickNames()[0] != "")
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
            //audioObj.SetActive(true);
            pauseObj.SetActive(false);
            pause = false;
            Cursor.visible = false;
        }
    }
}
