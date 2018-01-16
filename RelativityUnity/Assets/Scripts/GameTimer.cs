using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameTimer : MonoBehaviour {

    private float time;
    [SerializeField] private Text timeText;

	// Use this for initialization
	void Start () {
        time = 0;
        timeText.text = "00:00";
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timeText.text = time.ToString("00:00");
	}
}
