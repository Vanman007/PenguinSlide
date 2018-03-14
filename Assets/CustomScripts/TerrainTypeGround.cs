using UnityEngine;
using System.Collections;

public class TerrainTypeGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.layer = 2;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "Player") {
			MovePlayer.TerrainType = "Ground";
			Debug.Log("g");
		}
	}

}
