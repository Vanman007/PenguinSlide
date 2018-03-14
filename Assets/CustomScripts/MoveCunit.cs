using UnityEngine;
using System.Collections;

public class MoveCunit : MonoBehaviour {
	GameObject []CUnit = new GameObject[2];
	GameObject []CUPoint = new GameObject[2];
	Vector3 []CUnitVector = new Vector3[2];
	Vector3 []CUnitStart = new Vector3[2];
	float []time = new float[2];


	int NumberOfCUnit;
	// Use this for initialization
	void Start () {
		NumberOfCUnit=CUnit.Length;
		for (int i=0; i < NumberOfCUnit; i++) {
			CUnit[i] = GameObject.Find ("CUnit"+i);
			CUPoint[i] = GameObject.Find ("CUnitPoint"+i);
			CUnitStart[i]=CUnit[i].transform.position; // by this point reverse
		}	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i < NumberOfCUnit; i++) {
			if (time[i] > 6.28318530718) {
				time[i] = 0;
			}

		time[i]=time[i]+0.1f;
		CUnitVector[i].x=(float)CUnitStart[i].x+((float)Mathf.Abs(CUPoint[i].transform.position.z-CUnitStart[i].z)*Mathf.Sin(time[i]));
		CUnitVector [i].z =(float)CUnitStart[i].z+((float)Mathf.Abs(CUPoint[i].transform.position.z-CUnitStart[i].z)*Mathf.Cos(time[i]));
		CUnit[i].transform.position = new Vector3 (CUnitVector[i].x,CUnitStart[i].y,CUnitVector[i].z);

		
		}
	}
}
