using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenLevels : MonoBehaviour {

	[SerializeField]private Slider oxygenSlider;
	[SerializeField]private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		oxygenSlider.value -= Time.deltaTime / 10;
        if (oxygenSlider.value <= 0)
        {
            FirstPersonController FPC = GetComponentInParent<FirstPersonController>();
            FPC.set_gameOver(true, true);
        }
	}

    public void fillOxygen()
    {
        oxygenSlider.value = 100;
    }
}
