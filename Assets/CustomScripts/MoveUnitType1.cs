using UnityEngine;
using System.Collections;

public class MoveUnitType1 : MonoBehaviour {

	GameObject []PUnit = new GameObject[2];
	GameObject []PUPoint = new GameObject[2];
	Vector3 []PUnitVector = new Vector3[2];
	Vector3 []PUnitStart = new Vector3[2];
	bool []PUnitIsRevers = new bool[2];
	int NumberOfPUnit;

	// Use this for initialization
	void Start () {
		NumberOfPUnit=PUnit.Length;

		for (int i=0; i < NumberOfPUnit; i++) {
			PUnit[i] = GameObject.Find ("NormalUnit"+i);
			PUPoint[i] = GameObject.Find ("NormalUnitPoint"+i);
			PUnitStart[i]=PUnit[i].transform.position; // by this point reverse
		}	


	}

	// Update is called once per frame
	void Update () {
		for (int i=0; i < NumberOfPUnit; i++) {
			if (PUnitIsRevers[i] == true) {
				PUnitVector [i] = (PUnit [i].transform.position - PUnitStart [i]) * -1; 
				PUnit [i].transform.Translate (Vector3.ClampMagnitude (PUnitVector [i], (float)0.10));
				if (PUnitVector [i].magnitude < 0.75) {
					PUnitIsRevers[i] = false;
					PUnitVector [i] = (PUnit [i].transform.position - PUnitStart [i]) * 1;
					PUnit [i].transform.Translate (Vector3.ClampMagnitude (PUnitVector [i], (float)0.21));
				}
			}
			if (PUnitIsRevers[i] == false) {
				PUnitVector [i] = (PUnit [i].transform.position - PUPoint [i].transform.position) * -1; 
				PUnit [i].transform.Translate (Vector3.ClampMagnitude (PUnitVector [i], (float)0.10));
				if (PUnitVector [i].magnitude < 0.75) {
					PUnitIsRevers[i] = true;
					PUnitVector [i] = (PUnit [i].transform.position - PUPoint [i].transform.position) * 1;
					PUnit [i].transform.Translate (Vector3.ClampMagnitude (PUnitVector [i], (float)0.21));
				}
			}
			
		}
	}


}
