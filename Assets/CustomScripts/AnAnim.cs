using UnityEngine;
using System.Collections;

public class AnAnim : MonoBehaviour {
	public static Animator anim;
	public static bool waving=false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}	