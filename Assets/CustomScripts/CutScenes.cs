using UnityEngine;
using System.Collections;

public class CutScenes : MonoBehaviour {
	public static bool cutSceneIsOn=true;
	public static bool deathAnimIsOn=false;
	GameObject []CamMovement = new GameObject[3]; //skal være 1 over just for the gigels
	bool []CamReached = new bool[3]; //same som above
	GameObject []CamLookAt = new GameObject[3];
	GameObject MainCam;
	Quaternion SaveMainCamStateR;
	Vector3 SaveMainCamStateP;
	int CamsReached = 0;
	bool EndOfCutSceneRached=false;
	float delay=0;
	float deathAnimDelay=9999999999999999;
	bool thedelay=false;
	bool deathAnimTheDelay=false;
	double flyAnim;
	public GameObject player;
	public GameObject player1;
	public GameObject deadPlayer;
	public GameObject IceCube;
	Vector3 DontFkinMove = new Vector3(0,0,0);
	public static bool DeadByWater;
	bool applyThisOnce;
	public static bool TeleportToStart=false;

	// Use this for initialization
	void Start () {
		for (int i=0; i<CamLookAt.Length; i++) {
			CamMovement [i] = GameObject.Find ("CamPoint"+i);
			CamLookAt [i] = GameObject.Find ("CamLookAt"+i);
			CamReached [i] = false;
		}

		MainCam= GameObject.Find ("Main Camera");

		cutSceneIsOn = true;

		CamReached [0] = true;

		SaveMainCamStateR = MainCam.transform.rotation;
		SaveMainCamStateP = MainCam.transform.position;

		MainCam.transform.position = CamMovement[0].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (cutSceneIsOn == true) {
			for (int i=0; i<CamLookAt.Length-1; i++) {
				if ((MainCam.transform.position - CamMovement [i + 1].transform.position).magnitude < 0.05 && CamsReached >= CamReached.Length - 1) {
					EndOfCutSceneRached = true;

				} else if ((MainCam.transform.position - CamMovement [i + 1].transform.position).magnitude < 0.05) {
					CamReached [CamsReached] = false;
					CamReached [CamsReached + 1] = true;
					CamsReached++;
				}
				if (CamReached [i] == true) {
					MainCam.transform.position = Vector3.MoveTowards (MainCam.transform.position, CamMovement [i + 1].transform.position, (float)0.1);
					MainCam.transform.LookAt (CamLookAt [0].transform.position);
					CamLookAt [0].transform.position = Vector3.MoveTowards (CamLookAt [0].transform.position, CamLookAt [i + 1].transform.position, (float)0.1);
				}

				if (CamReached [CamLookAt.Length - 1] == true) {
					AnAnim.anim.SetBool ("Wave", true);
				}
			          
				if(Input.GetMouseButtonDown(1)){
					MainCam.transform.position = SaveMainCamStateP;
					MainCam.transform.rotation = SaveMainCamStateR;
					cutSceneIsOn=false;
				}

				if (EndOfCutSceneRached == true) {
					MainCam.transform.position = Vector3.MoveTowards (MainCam.transform.position, SaveMainCamStateP, (float)0.015);
					MainCam.transform.rotation = Quaternion.RotateTowards (MainCam.transform.rotation, SaveMainCamStateR, (float)0.15);
					if(thedelay==false){
					delay=Time.timeSinceLevelLoad+6;
						thedelay=true;
					}
				}


				if (MainCam.transform.rotation == SaveMainCamStateR && MainCam.transform.position == SaveMainCamStateP) {
					Debug.Log(Time.timeSinceLevelLoad);
					if(delay < Time.timeSinceLevelLoad){
					
						cutSceneIsOn=false;
					}

					//Player.transform.rotation = Quaternion.RotateTowards (Player.transform.rotation, new Vector3(CamLookAt [CamLookAt.Length - 1].transform.rotation, (float)3);

				
				}
			}
		}

		if (deathAnimIsOn == true) {
			applyThisOnce = true;
			//animation
			flyAnim = Time.deltaTime;
			if (DeadByWater == false) {
				deadPlayer.transform.position = deadPlayer.transform.position + new Vector3 (0, (float)flyAnim, 0);
			} else {
				if (deathAnimDelay-2 < Time.timeSinceLevelLoad ){
					IceCube.transform.position=player.transform.position+ new Vector3 (0, 1, 0);
				}
				if (deathAnimDelay-2 < Time.timeSinceLevelLoad && deathAnimDelay-1 > Time.timeSinceLevelLoad  ){
					player.transform.position =player.transform.position+ new Vector3 (0, (float)flyAnim, 0);
					IceCube.transform.position=IceCube.transform.position+ new Vector3 (0, (float)flyAnim, 0);
				}
			}

			if (deathAnimTheDelay == false) {
				if (DeadByWater == false) {
					DontFkinMove = player1.transform.position;
					deadPlayer.transform.position = player.transform.position;
					player.transform.position = new Vector3 (-100, 0, 0);
					AnAnimDead.animDead.SetBool ("Wave", true);
				} else {
					//IceCube.transform.position=player.transform.position- new Vector3 (0, 1, 0);
				}
				deathAnimDelay = Time.timeSinceLevelLoad + 3;
				deathAnimTheDelay = true;

			}

			if (DeadByWater == false) {
				player1.transform.position = DontFkinMove;
			}
		}

		if (applyThisOnce == true) {
			if (deathAnimDelay < Time.timeSinceLevelLoad) {
				applyThisOnce = false;
				deathAnimIsOn = false;
				deathAnimTheDelay = false; 
				player1.transform.position = CheckBounds.StartPos;
				player.transform.position = CheckBounds.StartPos;
				MovePlayer.TerrainType = "Ground";
				if(PlayerPrefs.GetInt ("CurrentLevel")!=10){
				MovePlayer.PlayerSpeed = 0.15;
				}
				deadPlayer.transform.position =new Vector3(-100,0,0);
				IceCube.transform.position=new Vector3(-100,0,0);
				AnAnimDead.animDead.SetBool ("Wave", false);
				deathAnimDelay=9999999999999999;
				EndReached.resetScript=true;
			}
		}

		if (TeleportToStart == true) {
			player1.transform.position = CheckBounds.StartPos;
			player.transform.position = CheckBounds.StartPos;
			TeleportToStart = false;
		}
		//	then move
		//	if mag of cam 1 and 2 = less than 0.75
		//	then int[0]=true
		//  	
		//	if Cam..[i]



	}
}
