using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    enum GameState { START, MAIN, HELP, IN_GAME };
    [SerializeField] private GameState gameState;
    [SerializeField] private GameState startState = GameState.START;

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject HelpMenu;

	// Use this for initialization
	void Start () {
        gameState = startState;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnChangeState(GameState newState)
    {
        if (gameState != newState)
        {

            switch (newState)
            {
                case GameState.START:
                    Time.timeScale = 0;
                    SceneManager.LoadScene("MainMenu");

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    StartCoroutine(WaitForEndOfFrame());

                    break;
                case GameState.HELP:
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    HelpMenu.SetActive(true);
                    MainMenu.SetActive(false);


                    StartCoroutine(WaitForEndOfFrame());

                    break;
                case GameState.MAIN:
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    MainMenu.SetActive(true);
                    HelpMenu.SetActive(false);

                    StartCoroutine(WaitForEndOfFrame());

                    break;

                case GameState.IN_GAME:
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = false;

                    StartCoroutine(WaitForEndOfFrame());
                    break;
            }

            gameState = newState;
        }
    }

    private void EnableInput(bool input)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<FirstPersonController>().enabled = input;
    }

    IEnumerator WaitForEndOfFrame()
    {

        yield return new WaitForEndOfFrame();
    }

    public void Menu()
    {
        OnChangeState(GameState.START);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        OnChangeState(GameState.IN_GAME);
    }

    public void Help()
    {
        OnChangeState(GameState.HELP);
    }

    public void Return()
    {
        OnChangeState(GameState.MAIN);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
