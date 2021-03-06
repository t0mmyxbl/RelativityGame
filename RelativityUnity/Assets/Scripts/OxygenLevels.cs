﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenLevels : MonoBehaviour {

	[SerializeField] private Slider oxygenSlider;
	[SerializeField] private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		oxygenSlider.value -= Time.deltaTime * speed;
        if (oxygenSlider.value <= 0)
        {
            FirstPersonController FPC = GetComponentInParent<FirstPersonController>();
            FPC.Set_gameOver(true, true);
        }
	}

    public void FillOxygen()
    {
        oxygenSlider.value = 100;
    }
}
