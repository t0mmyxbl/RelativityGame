using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	enum GameState { START, MAIN, OPTIONS, IN_GAME, PAUSED, END};
	private GameState gameState;

	[SerializeField] private GameState startState = GameState.START;
	[SerializeField] private GameObject UserInterface;
	[SerializeField] private GameObject MainMenu;
	[SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject PauseMenu;

    static private GameManager instance = null;

	public static GameManager Instance
	{
		get
		{
			return instance;
		}
	}

	void Awake(){
		if (instance != null) {
			Destroy (gameObject);

			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		gameState = startState;
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			OnChangeState (GameState.PAUSED);
        }
    }

	void OnChangeState (GameState newState) {
		if (gameState != newState) {

			switch (newState) 
			{
			case GameState.START:
				Time.timeScale = 0;
				SceneManager.LoadScene ("MainMenu");

				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

				StartCoroutine (WaitForEndOfFrame ());

				break;
			case GameState.OPTIONS:
				Time.timeScale = 0;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

                PauseMenu.SetActive(false);
				MainMenu.SetActive (false);
				OptionsMenu.SetActive(true);

				StartCoroutine (WaitForEndOfFrame ());

				break;
			case GameState.IN_GAME:
				Time.timeScale = 1;
				SceneManager.LoadScene ("Game");

				StartCoroutine (WaitForEndOfFrame ());
				break;
			case GameState.PAUSED:
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

				Time.timeScale = 0;

				Transform pauseMenuInstance = Instantiate (PauseMenu).transform;
				pauseMenuInstance.SetParent (UserInterface.transform, false);
				StartCoroutine (WaitForEndOfFrame ());
				break;
			case GameState.END:

				StartCoroutine (WaitForEndOfFrame ());
				break;
			case GameState.MAIN:
				Time.timeScale = 0;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

				MainMenu.SetActive(true);
				OptionsMenu.SetActive(false);

				StartCoroutine (WaitForEndOfFrame ());

				break;
			}

			gameState = newState;
		}
	}

	private void EnableInput(bool input){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<FirstPersonController> ().enabled = input;
	}

	IEnumerator WaitForEndOfFrame(){

		yield return new WaitForEndOfFrame ();
	}

	public void Menu(){
		OnChangeState (GameState.START);
	}

	public void PlayGame(){
		OnChangeState (GameState.IN_GAME);
	}

	public void Options(){
		OnChangeState (GameState.OPTIONS);
	}

    public void Resume(){
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

	public void End(){
		OnChangeState (GameState.END);
	}

	public void Return(){
		OnChangeState (GameState.MAIN);
	}

	public void Quit(){
		Application.Quit();
	}
}
