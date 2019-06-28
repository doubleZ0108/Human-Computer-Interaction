using UnityEngine;
using System.Collections;

public class enciende : MonoBehaviour {

	public GameObject elCubo;
	private bool isOn=false;
	public GameObject DirectionalLight;
	private bool DirLightIsOn=true;
    
	void OnGUI() {
		if (GUI.Button (new Rect (20, 20, 150, 40), "Aircraft On/Off")) {
			if (!isOn) {
				shaderGlow gls= elCubo.GetComponent<shaderGlow>();
				gls.lightOn();
				isOn=true;
			}
			else {
				shaderGlow gls= elCubo.GetComponent<shaderGlow>();
				gls.lightOff();
				isOn=false;
			}
		}		
	}
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
