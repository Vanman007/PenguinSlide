using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	public  static string TerrainType = "Ground";
	public  Vector3 PlayerVelVec = new Vector3(0,0,0);
	public  Vector3 PlayerVelVecInvis = new Vector3(0,0,0);
	public bool mouseclicked=false;
	public double vinkeldiff=0;
	public double vinkel=0;
	public double angle=0;
	public double a1=0;
	public double a2=0;
	public static double PlayerSpeed;
	public GameObject Cursor;
	public static Vector3 PlayerPosition = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
		PlayerSpeed = 0.15;
		gameObject.layer = 2;
		Cursor = GameObject.Find ("TestCursor");
		MovePlayer.TerrainType = "Ground";


	}
	
	// Update is called once per frame
	void Update () {
		PlayerPosition = transform.position;


		if (Input.GetMouseButtonDown (1)) {
			mouseclicked = true;
		}
		if (Input.GetMouseButtonUp (1)) {
			mouseclicked = false;
		}
		if (CutScenes.cutSceneIsOn == false) {
			if(CutScenes.deathAnimIsOn == false){
				transform.rotation = Quaternion.LookRotation(new Vector3(PlayerVelVec.x,0,PlayerVelVec.z));
			//transform.LookAt(Cursor.transform.position);
			IsOnGround ();
			IsOnIce ();
			}
		}
		//Debug.Log (PlayerVelVec);
	}



	void IsOnGround(){
		if (TerrainType == "Ground") {
			if (mouseclicked == true) {
				PlayerVelVec = MoveCursorScript.CursorPos - CheckBounds.PlayerPos;
				if (PlayerVelVec.magnitude > 1) {
					transform.Translate (Vector3.ClampMagnitude (PlayerVelVec, (float)PlayerSpeed), Space.World);
					angle=(a1+90)*(Mathf.PI/180);


				}
			}
		}
	
	}



	void IsOnIce(){
		PlayerVelVecInvis = MoveCursorScript.CursorPos - CheckBounds.PlayerPos;
		if (PlayerVelVecInvis.x > 0) { 
			if (PlayerVelVecInvis.z < 0) {
				a2 = ((PlayerVelVecInvis.z) / Mathf.Sqrt (PlayerVelVecInvis.z * PlayerVelVecInvis.z + PlayerVelVecInvis.x * PlayerVelVecInvis.x)) * -90;
			}
		}
		if (PlayerVelVecInvis.x > 0) { 
			if (PlayerVelVecInvis.z > 0) {
				a2 = Mathf.Abs (((PlayerVelVecInvis.z) / Mathf.Sqrt (PlayerVelVecInvis.z * PlayerVelVecInvis.z + PlayerVelVecInvis.x * PlayerVelVecInvis.x)) * 90 - 360);
			}
		}
		if (PlayerVelVecInvis.x < 0) { 
			if (PlayerVelVecInvis.z < 0) {
				a2 = Mathf.Abs ((PlayerVelVecInvis.z) / Mathf.Sqrt (PlayerVelVecInvis.z * PlayerVelVecInvis.z + PlayerVelVecInvis.x * PlayerVelVecInvis.x) * -90 - 180);
			}
		}
		if (PlayerVelVecInvis.x < 0) { 
			if (PlayerVelVecInvis.z > 0) {
				a2 = Mathf.Abs ((PlayerVelVecInvis.z) / Mathf.Sqrt (PlayerVelVecInvis.z * PlayerVelVecInvis.z + PlayerVelVecInvis.x * PlayerVelVecInvis.x) * -90 - 180);
			}
		}
	//if (TerrainType == "Ice") {
			if (PlayerVelVec.x >= 0) {  
				if (PlayerVelVec.z <= 0) {
					a1 = ((PlayerVelVec.z) / Mathf.Sqrt (PlayerVelVec.z * PlayerVelVec.z + PlayerVelVec.x * PlayerVelVec.x)) * -90;
				}
			}
			if (PlayerVelVec.x > 0) {  
				if (PlayerVelVec.z > 0) {
					a1 = Mathf.Abs (((PlayerVelVec.z) / Mathf.Sqrt (PlayerVelVec.z * PlayerVelVec.z + PlayerVelVec.x * PlayerVelVec.x)) * 90 - 360);
				}
			}
			if (PlayerVelVec.x < 0) { 
				if (PlayerVelVec.z < 0) {
					a1 = Mathf.Abs ((PlayerVelVec.z) / Mathf.Sqrt (PlayerVelVec.z * PlayerVelVec.z + PlayerVelVec.x * PlayerVelVec.x) * -90 - 180);
				}
			}
			if (PlayerVelVec.x < 0) { 
				if (PlayerVelVec.z > 0) {
					a1 = Mathf.Abs ((PlayerVelVec.z) / Mathf.Sqrt (PlayerVelVec.z * PlayerVelVec.z + PlayerVelVec.x * PlayerVelVec.x) * -90 - 180);
				}
			}
	//	}
		vinkeldiff = a1 - a2;
		if (vinkeldiff < 0) {
			vinkel = vinkeldiff;
			vinkel = 360 + vinkel;
		} else {
			vinkel = vinkeldiff;
		}
		if (TerrainType == "Ice") {
			//Debug.Log ("Ice:"+angle);
			if (mouseclicked == true) {
				if (vinkel < 180 && vinkel > 0) {
					angle = angle - 0.1; 
				}
				if (vinkel < 360 && vinkel > 180) {
					angle = angle + 0.1; 
				}

				PlayerVelVec.z = 3 * Mathf.Cos ((float)angle);
				PlayerVelVec.x = 3 * Mathf.Sin ((float)angle);
			}
			transform.Translate (Vector3.ClampMagnitude (PlayerVelVec, (float)PlayerSpeed), Space.World);
		}
	}
		
	//void ice slut



	}




