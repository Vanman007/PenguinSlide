using UnityEngine;
using System.Collections;

public class Speed5Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "Player") {
			MovePlayer.PlayerSpeed = MovePlayer.PlayerSpeed+0.15;
		}
	}

}
