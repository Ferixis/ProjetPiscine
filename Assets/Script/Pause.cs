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
        if (!pause)
        {
            Time.timeScale = 0;
            player.GetComponent<PlayerMoves>().enabled = false;
           // audioObj.SetActive(false);
            pauseObj.SetActive(true);
            pause = true;
            EventSystem.current.SetSelectedGameObject(continueButton);
            Cursor.visible = true;
        }
        else
        {
            
            Time.timeScale = 1;
            player.GetComponent<PlayerMoves>().enabled = true;
            //audioObj.SetActive(true);
            pauseObj.SetActive(false);
            pause = false;
            Cursor.visible = false;
        }
    }
}
