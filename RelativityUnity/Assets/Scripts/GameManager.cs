using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	enum GameState { START, MAIN, HELP, IN_GAME, PAUSED, END};
	 [SerializeField] private GameState gameState;
	[SerializeField] private GameState startState = GameState.START;

	[SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject MainHelpMenu;
	[SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject TimeManager;
    [SerializeField] private Text endMessage;
    private GameTimer gameTimer;
    private FirstPersonController FPC;

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
        FPC = player.GetComponent<FirstPersonController>();
        gameTimer = TimeManager.GetComponent<GameTimer>();
		gameState = startState;
	}

    void Update()
    {
        if (FPC.Get_gameOver())
        {
            if (FPC.Get_Death())
            {
                endMessage.text = "You died!";
            }
            else
            {
                endMessage.text = "You made it in " + gameTimer.GetTime();
            }

            OnChangeState(GameState.END);
        }

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
			case GameState.HELP:
				Time.timeScale = 0;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

                MainHelpMenu.SetActive(true);
                MainMenu.SetActive(false);
                

				StartCoroutine (WaitForEndOfFrame ());

				break;
			case GameState.IN_GAME:
				Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;

                PauseMenu.SetActive(false);

				StartCoroutine (WaitForEndOfFrame ());
				break;
			case GameState.PAUSED:
				Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

                PauseMenu.SetActive(true);

				StartCoroutine (WaitForEndOfFrame ());
				break;
			case GameState.END:
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    SceneManager.LoadScene("EndScreen");

                    StartCoroutine (WaitForEndOfFrame ());
				break;
			case GameState.MAIN:
				Time.timeScale = 0;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

                MainMenu.SetActive(true);
                MainHelpMenu.SetActive(false);

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
        SceneManager.LoadScene("Game");
        OnChangeState (GameState.IN_GAME);
	}

	public void Help(){
		OnChangeState (GameState.HELP);
	}

    public void Resume(){
        OnChangeState(GameState.IN_GAME);
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
