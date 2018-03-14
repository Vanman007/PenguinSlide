using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndReached : MonoBehaviour {
	public static int HighestLevel;
	public static int CurrentLevel;
	//public static int []LevelScores = new int[1];

	public Text timeText;

	float []StageClear1 = new float[25];
	float []StageClear2 = new float[25];
	
	//time
	float milsec;
	int sec;
	int min;
	int hou;
	string timedis;
	
	int levelscoreints;
	
	float Trial;
	int andError;
	public static bool resetScript=true;



	void Start () {
		CurrentLevel = PlayerPrefs.GetInt ("CurrentLevel");

		//husk at -1
		StageClear1 [0] = 10;
		StageClear2 [0] = 60 * 5;

		StageClear1 [1] = 7;
		StageClear2 [1] = 10;

		StageClear1 [2] = 7;
		StageClear2 [2] = 13;

		StageClear1 [3] = 12;
		StageClear2 [3] = 30;

		StageClear1 [4] = 99999999;
		StageClear2 [4] = -1;

		StageClear1 [5] = 6;
		StageClear2 [5] = 8;

		StageClear1 [6] = 8;
		StageClear2 [6] = 15;

		StageClear1 [7] = 8;
		StageClear2 [7] = 10;

		StageClear1 [8] = 14;
		StageClear2 [8] = 20;

		StageClear1 [9] = 999999999999999;
		StageClear2 [9] = -1;

		StageClear1 [10] = 999999999999999;

		StageClear1 [11] = 999999999999999;

	
	}
	
	
	void Update () {
		if(CutScenes.deathAnimIsOn==true){
			sec=0;
			milsec=-1;
			min=0;
			hou=0;
		}


		if (CutScenes.cutSceneIsOn == false) {
			//texts
			//Adding milliseconds
			milsec += Time.timeScale;
			//Adding seconds
			if(Mathf.Floor (milsec) >= 60){milsec = 0; sec = sec +1;}
			//adding minutes
			if(sec >= 60) {sec = 0; min = min +1;}
			//Adding hours
			if(min >= 60){min = 0; hou = hou +1;}
			//Display time
			timedis = (hou.ToString() + ":" + min.ToString() + ":" + sec.ToString () + ":" + Mathf.Floor(milsec).ToString());
			timeText.text= "" + timedis;

	
			if (resetScript==true){
				resetScript=false;
				Trial=Time.timeSinceLevelLoad;
			}

		}
		
	}
	
	void OnTriggerExit(Collider other) {
		HighestLevel = PlayerPrefs.GetInt ("Level");
		if (other.gameObject.name == "Player") {
			if(HighestLevel <= CurrentLevel){
				HighestLevel=CurrentLevel+1;
			}
			PlayerPrefs.SetInt ("Level"+(CurrentLevel-1)+"DoneIn", 1);
			if(StageClear2[(CurrentLevel-1)] > Time.timeSinceLevelLoad-Trial){
				PlayerPrefs.SetInt ("Level"+(CurrentLevel-1)+"DoneIn", 2);
			}
			if(StageClear1[(CurrentLevel-1)] >Time.timeSinceLevelLoad-Trial){
				PlayerPrefs.SetInt ("Level"+(CurrentLevel-1)+"DoneIn", 3);
			}


			PlayerPrefs.SetInt ("Level", HighestLevel);
			Application.LoadLevel("Menu");
		}
	}
	
	
}
