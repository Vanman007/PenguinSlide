using UnityEngine;
using System.Collections;

public class Speed10Trigger : MonoBehaviour {
	int numberOfSpeedBoosts;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "Player") {
			if(this.gameObject.Equals(GameObject.Find("SpeedTrigger1"))==true)
			{
				if(MovePlayer.PlayerSpeed < 0.20)	MovePlayer.PlayerSpeed = 0.20;
			}
			if(this.gameObject.Equals(GameObject.Find("SpeedTrigger2"))==true)
			{
				if(MovePlayer.PlayerSpeed < 0.25)MovePlayer.PlayerSpeed = 0.25;
			}
			if(this.gameObject.Equals(GameObject.Find("SpeedTrigger3"))==true)
			{
				if(MovePlayer.PlayerSpeed < 0.30)MovePlayer.PlayerSpeed = 0.30;
			}

			CutScenes.TeleportToStart=true;
		}
	}

}
