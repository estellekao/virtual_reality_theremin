using UnityEngine;
using System.Collections;

public class AudioEffects : MonoBehaviour {
	public AudioEffects audioEffect;

	public int delay = 50;
	public float decay = 0.5f;
	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
		if (BodySourceView.handRight.x > 2) {
				  delay = 500;	
				}

	}
}
