using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_menu : MonoBehaviour
{
    public GameObject PausePanel;
	public static bool pause_menu_state = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  // KeyCode.Escape
        {
            // set pause menu
			if (pause_menu_state == false)
			{
				Pause();
			}
			else
			{
				Resume();
			}
        }
    }

	public void Pause()
	{
		Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

		PausePanel.SetActive(true);
		Time.timeScale = 0;
		pause_menu_state = true;
	}
	public void Resume()
	{
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

		PausePanel.SetActive(false);
		Time.timeScale = 1;
		pause_menu_state = false;
	}
	public void Param()
	{
		Debug.Log("Test bouton param");
	}
	public void Quit()
	{
		Application.Quit();
	}
}
