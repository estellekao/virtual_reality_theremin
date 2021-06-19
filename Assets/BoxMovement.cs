using UnityEngine;
using System.Collections;

public class BoxMovement : MonoBehaviour {

	void Start () {
	}

	// Update is called once per frame
	void Update () {

		// when user presses escape key...
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			// quit application...
			Application.Quit();
		}


//		float Vol = BodySourceView.handRight.y;

		//float Note = BodySourceView.handRight.x;
		// This code allows you to use mathamatical forumlas to modify the pitch.
//		float Note_distance = Mathf.Sqrt((BodySourceView.handRightTip.y - BodySourceView.wristRight.y)*(BodySourceView.handRightTip.y - BodySourceView.wristRight.y)+
//			(BodySourceView.handRightTip.x - BodySourceView.wristRight.x)*(BodySourceView.handRightTip.x - BodySourceView.wristRight.x));
//		float Note_height = (BodySourceView.handRightTip.y+BodySourceView.wristRight.y);
//		float Note_angle = (Mathf.Asin (Note_height / Note_distance));
//		float Note = Mathf.Abs (Note_distance * (Mathf.Cos (Note_angle)));

		//float Pitch=BodySourceView.handLeft

		//Debug.Log (Vol);
		//Debug.Log (Note);

//		if (Vol< 0) {
//		//	audio.volume=0.0F;
//		}else {
//			if (Vol>=0){
//		//		audio.volume=Vol/10;
//			}
//			else if (Vol>=10){
//		//		audio.volume=Vol/100;
//			}
//			else if(Vol>=100){
//		//		audio.volume=Vol/1000;
//			}
//		}
		//use this code to impliment the muscial controler multiple keys application
//		if (Note < -3.5) {
//				} else if (Note >= -3.5 || Note < -2.8) {
//				} else if (Note >= -2.8 || Note < -2.1) {
//				} else if (Note >= -2.1 || Note < -1.4) {
//				} else if (Note >= -1.4 || Note < -0.7) {
//				} else if (Note >= -0.7 || Note < 0) {
//				} else if (Note >= 0 || Note < 0.7) {
//				} else if (Note >= 0.7 || Note < 1.4) {
//				} else if (Note >= 1.4 || Note < 2.1) {
//				} else if (Note >= 2.1 || Note < 2.8) {
//				} else if (Note >= 2.8 || Note < 3.5) {
//				}else if (Note>=3.5){
//
//		}

	}
}