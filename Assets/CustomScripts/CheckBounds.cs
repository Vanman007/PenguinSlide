using UnityEngine;
using System.Collections;

public class CheckBounds : MonoBehaviour {
	public static Vector3 PlayerPos = new Vector3(0,0,0);
	public static Vector3 StartPos = new Vector3(15,7,27);



	// Use this for initialization
	void Start () {
		StartPos  = transform.position;
	}

	// Update is called once per frame
	void Update () {
		//check if out of bounds and reset player if it is
		PlayerPos  = transform.position;

		if (PlayerPos.y < 2.5 &&  PlayerPrefs.GetInt("CurrentLevel")!=10) {
			//transform.position = StartPos;
			//MovePlayer.TerrainType = "Ground";
			//MovePlayer.PlayerSpeed =0.15;
			CutScenes.deathAnimIsOn=true;
			CutScenes.DeadByWater=true;
		}
		if(PlayerPos.y < -12  &&  PlayerPrefs.GetInt("CurrentLevel")==10)
			{
			CutScenes.deathAnimIsOn=true;
			CutScenes.DeadByWater=true;
		}


	}

	
}
