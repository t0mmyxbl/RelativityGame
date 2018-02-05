using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameTimer : MonoBehaviour {

    private float time;
    [SerializeField] private Text timer;
    public static string timeText;
    [SerializeField] private GameObject Player;
    private FirstPersonController FPC;

	// Use this for initialization
	void Start () {
        FPC = Player.GetComponent<FirstPersonController>();
        time = 0;
        timer.text = "00:00";
        timeText = timer.text;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = Mathf.Floor(time % 60).ToString("00");
        timer.text = minutes+":"+seconds;
        timeText = timer.text;
	}

    public static string GetTime()
    {
        return timeText;
    }
}
