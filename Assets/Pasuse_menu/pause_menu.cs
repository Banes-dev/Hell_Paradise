using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_menu : MonoBehaviour
{
    public GameObject PausePanel;
	public string pause_menu_state = "play";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Y))  // KeyCode.Escape
        {
            // set pause menu
			if (pause_menu_state == "play")
			{
				Pause();
			}
			else if (pause_menu_state == "pause")
			{
				Resume();
			}
        }
    }

	public void Pause()
	{
		PausePanel.SetActive(true);
		Time.timeScale = 0;
		pause_menu_state = "pause";
	}
	public void Resume()
	{
		PausePanel.SetActive(false);
		Time.timeScale = 1;
		pause_menu_state = "play";
	}
	public void Quit()
	{
		Application.Quit();
	}
}
