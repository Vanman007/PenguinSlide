using UnityEngine;
using System.Collections;

public class MenuScript2 : MonoBehaviour {
	public Canvas myCanvas;
	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)||Input.GetMouseButton (0)) {
			myCanvas.GetComponent<CanvasGroup> ().alpha = 1;
			myCanvas.GetComponent<CanvasGroup> ().interactable = true;
		}

	}
}
