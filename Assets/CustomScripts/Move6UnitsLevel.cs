using UnityEngine;
using System.Collections;

public class Move6UnitsLevel : MonoBehaviour {
	//cunit
	GameObject []CUnit = new GameObject[6];
	GameObject []CUPoint = new GameObject[6];
	Vector3 []CUnitVector = new Vector3[6];
	Vector3 []CUnitStart = new Vector3[6];
	float []time = new float[6];
	//punit
	GameObject []PUnit = new GameObject[8];
	GameObject []PUPoint = new GameObject[8];
	Vector3 []PUnitVector = new Vector3[8];
	Vector3 []PUnitStart = new Vector3[8];
	bool []PUnitIsRevers = new bool[8];
	
	int NumberOfPUnit;
	int NumberOfCUnit;
	
	// Use this for initialization
	void Start () {
		
		NumberOfCUnit=CUnit.Length;
		for (int i=0; i < NumberOfCUnit; i++) {
			CUnit[i] = GameObject.Find ("CUnit"+i);
			CUPoint[i] = GameObject.Find ("CUnitPoint"+i);
			CUnitStart[i]=CUnit[i].transform.position; // by this point reverse
		}	
		NumberOfPUnit=PUnit.Length;
		for (int i=0; i < NumberOfPUnit; i++) {
			PUnit[i] = GameObject.Find ("NormalUnit"+i);
			PUPoint[i] = GameObject.Find ("NormalUnitPoint"+i);
			PUnitStart[i]=PUnit[i].transform.position; // by this point reverse
			PUnit [i].transform.LookAt(PUPoint[i].transform.position);
			PUnit[i].transform.Rotate(0, 180, 0, Space.World);
		}	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i < NumberOfPUnit; i++) {
			
			if (PUnitIsRevers[i] == true) {
				PUnitVector [i] = (PUnit [i].transform.position - PUnitStart [i]) * -1; 
				
				PUnit [i].transform.Translate (Vector3.ClampMagnitude (PUnitVector [i], (float)0.10),Space.World);
				if (PUnitVector [i].magnitude < 0.75) {
					PUnit[i].transform.Rotate(0, 180, 0, Space.World);
					PUnitIsRevers[i] = false;
					PUnitVector [i] = (PUnit [i].transform.position - PUnitStart [i]) * 1;
					PUnit [i].transform.Translate (Vector3.ClampMagnitude (PUnitVector [i], (float)0.21),Space.World);
				}
			}
			if (PUnitIsRevers[i] == false) {
				PUnitVector [i] = (PUnit [i].transform.position - PUPoint [i].transform.position) * -1; 
				PUnit [i].transform.Translate (Vector3.ClampMagnitude (PUnitVector [i], (float)0.10),Space.World);
				if (PUnitVector [i].magnitude < 0.75) {
					PUnit[i].transform.Rotate(0, 180, 0, Space.World);
					PUnitIsRevers[i] = true;
					PUnitVector [i] = (PUnit [i].transform.position - PUPoint [i].transform.position) * 1;
					PUnit [i].transform.Translate (Vector3.ClampMagnitude (PUnitVector [i], (float)0.21),Space.World);
				}
			}
		}
		for (int i=0; i < NumberOfCUnit; i++) {
			if (time[i] > 6.28318530718) {
				time[i] = 0;
			}
			
			time[i]=time[i]+0.07f;
			CUnitVector[i].x=(float)CUnitStart[i].x+((float)Mathf.Abs(CUPoint[i].transform.position.z-CUnitStart[i].z)*Mathf.Sin(time[i]));
			CUnitVector [i].z =(float)CUnitStart[i].z+((float)Mathf.Abs(CUPoint[i].transform.position.z-CUnitStart[i].z)*Mathf.Cos(time[i]));
			CUnit[i].transform.position = new Vector3 (CUnitVector[i].x,CUnitStart[i].y,CUnitVector[i].z);
			CUnit[i].transform.Rotate(new Vector3(0,0.07f*(180/Mathf.PI),0));
			
		}
		
	}
}