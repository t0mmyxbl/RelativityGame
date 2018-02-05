using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTime : MonoBehaviour {

    [SerializeField] private Text EndMessage;

	// Use this for initialization
	void Start () {

        if (FirstPersonController.Get_Death())
            {
                EndMessage.text = "You died!";
            }
            else
            {
                EndMessage.text = "You reached the end in " + GameTimer.GetTime();
            }

	}
}
