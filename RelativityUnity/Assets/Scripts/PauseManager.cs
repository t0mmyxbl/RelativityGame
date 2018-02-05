using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour{

    [SerializeField] private GameObject PauseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        PauseMenu.SetActive(true);

        StartCoroutine(WaitForEndOfFrame());

    }

    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;

        PauseMenu.SetActive(false);

        StartCoroutine(WaitForEndOfFrame());
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator WaitForEndOfFrame()
    {

        yield return new WaitForEndOfFrame();
    }
}
