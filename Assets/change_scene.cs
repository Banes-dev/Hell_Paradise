using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour
{
	public string scenenane_actual;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
		{
			if (scenenane_actual == "Paradise")
			{
				// change to Hell
				SceneManager.LoadScene("Hell");
			}
			else if (scenenane_actual == "Hell")
			{
				// change to Paradise
				SceneManager.LoadScene("Paradise");
			}
		}
    }
}
