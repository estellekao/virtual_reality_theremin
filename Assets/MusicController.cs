using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
		

	private float pitch = 0.0f;
	private float volume = 0.0f;
	//private int delay = 0;
	private float decay = 0.0f;

//	private float Note ;

	// Use this for initialization
	void Start () {
		if (!GetComponent<AudioSource>() .isPlaying) {
			GetComponent<AudioSource>().Play ();
		}
//		effectTwo = new AudioEchoFilter ();
//		effectTwo = gameObject.AddComponent<AudioSource> ();

		//effectOne = new AudioEchoFilter() ;
		//effectOne = gameObject.AddComponent<AudioEchoFilter> ();
//			effectOne .delay = delay;
//			effectOne .decayRatio = decay;

				// launch volume off
//			audioSource = new AudioSource[audioClip.Length];
//
//				for (int i=0; i < audioSource.Length; i++) {
//					audioSource[i] = gameObject.AddComponent<AudioSource>();
//						audioSource[i].clip = audioClip[i];
//						audioSource[i].loop = true;
//						audioSource[i].volume = volume;
//						audioSource[i].pitch = pitch;
						
	
				//}
		}

	// Update is called once per frame
	void Update () {
		if (!GetComponent<AudioSource>() .isPlaying) {
			GetComponent<AudioSource>().Play ();
		}


//		Note = Mathf.Lerp (0.0f, 4.0f, Mathf.InverseLerp(-2.0f, 2.0f, BodySourceView.handRight.x));


		pitch = Mathf.Lerp (-3.0f, 3.0f, Mathf.InverseLerp(-16.0f, 8.0f, BodySourceView.handLeft.y));
		volume = Mathf.Lerp (0.0f, 1.0f, Mathf.InverseLerp (0.0f, 2.0f, BodySourceView.handRight.y));

		if (BodySourceView.handRight.x > 2) { 
						GetComponent<AudioSource>() .volume = volume;
						for (int i = 0; i < 3; i++) {

								decay = 0.5f;
								volume = volume * decay;
						}

				}
		if (!GetComponent<AudioSource>() .isPlaying) {
			GetComponent<AudioSource>().Play ();
		}
		//Commented code impliments a Audio Echo filter that can be turned on by uncommenting
		//		Debug.Log (BodySourceView.handLeft.y);
//		if (!audioSource [0].isPlaying) {
//						audioSource [0].Play ();
//				}
		//effectTwo .decayRatio = decay;
		//effectTwo .delay = delay;
		GetComponent<AudioSource>() .volume = volume;
		GetComponent<AudioSource>() .pitch = pitch;
		//effectOne .delay = delay;
		//effectOne .decayRatio = decay;


		//if (BodySourceView.handRight.x > 2) {
			
			//audio .effectOne .delay = 500.0f;
			
			//effectOne = effectOne.delay;
			//effectOne.decayRatio = 0.7f;
			//audio .Stop ();
		//}
//
	





		//this code impliments the ability to switch to other frequenys when moving your right hand over a x domain, requires multiple audio sources


//		if (Note < -1) {
//						//for (int i = 0; i < audioSource.Length; i++) {
//								//audioSource [i].Stop ();
//						//}
//						audioSource [0].Play ();
//						audioSource [0].loop = true;
//						audioSource [0].volume = volume;
//						audioSource [0].pitch = pitch;
//
//				} else if (Note >= 0 || Note < -1) {
//						for (int i = 0; i < audioSource.Length; i++) {
//								audioSource [i].Stop ();
//						}
//						audioSource [1].loop = true;
//						audioSource [1].Play ();
//						audioSource [1].volume = volume;
//						audioSource [1].pitch = pitch;
//				
//							
//				} else if (Note >= 1 || Note < 0) {
//						for (int i = 0; i < audioSource.Length; i++) {
//							audioSource [i].Stop ();
//						}
//						audioSource [2].loop = true;
//						audioSource [2].Play ();
//						audioSource [2].volume = volume;
//						audioSource [2].pitch = pitch;
//					
//				} else if (Note >= 2 || Note < 1) {
//						for (int i = 0; i < audioSource.Length; i++) {
//							audioSource [i].Stop ();
//						}
//						audioSource [3].loop = true;
//						audioSource [3].Play ();
//						audioSource [3].volume = volume;
//						audioSource [3].pitch = pitch;
//					
//				} else if (Note > 2 ) {
//					for (int i = 0; i < audioSource.Length; i++) {
//							audioSource [i].Stop ();
//						}
//						audioSource [1].loop = true;
//						audioSource [1].Play ();
//						audioSource [1].volume = volume;
//						audioSource [1].pitch = pitch;
//					
////
////
////
////
////
////							} else if (Note >= -0.7 || Note < 0) {
////							} else if (Note >= 0 || Note < 0.7) {
////							} else if (Note >= 0.7 || Note < 1.4) {
////							} else if (Note >= 1.4 || Note < 2.1) {
////							} else if (Note >= 2.1 || Note < 2.8) {
////							} else if (Note >= 2.8 || Note < 3.5) {
////							}else if (Note>=3.5){
////			
//					
////	
//				}


	}
}
