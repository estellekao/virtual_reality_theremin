using UnityEngine;
using System.Collections;

public class RightHand : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (-20.7627f+(BodySourceView.handRight.x / 2.0f), transform.position.y+(BodySourceView.handRight.y * 2.0f), transform.position.z);
	
	}
}
