using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCountBehaviour : MonoBehaviour
{

	Text ammoDisplay;

 	// Start is called before the first frame update
    void Start()
    {
        ammoDisplay = GetComponent<Text>();
    }

	public void ShowAmmo(float currentAmmo, float maxAmmo)
	{
		if (ammoDisplay != null) {
			ammoDisplay.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
		}
	}
}
