using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    // Pause System //

    public bool pause = false;
    public Transform player;
    public GameObject pauseObj;
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

    void PauseMode()
    {
        if (pause == false)
        {
            Time.timeScale = 0;
            player.GetComponent<PlayerMoves>().enabled = false;
           // audioObj.SetActive(false);
            pauseObj.SetActive(true);
            pause = true;
        }
        else
        {
            Time.timeScale = 1;
            player.GetComponent<PlayerMoves>().enabled = true;
            //audioObj.SetActive(true);
            pauseObj.SetActive(false);
            pause = false;
        }
    }
}
