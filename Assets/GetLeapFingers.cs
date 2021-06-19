/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2020.                                   *
 * Ultraleap proprietary and confidential.                                    *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using UnityEngine;
using System.Collections;
using System;
using Leap.Unity.Attributes;
using Leap;

namespace Leap.Unity
{

    /**
     * Detects when specified fingers are in an extended or non-extended state.
     * 
     * You can specify whether each finger is extended, not extended, or in either state.
     * This detector activates when every finger on the observed hand meets these conditions.
     * 
     * If added to a HandModelBase instance or one of its children, this detector checks the
     * finger state at the interval specified by the Period variable. You can also specify
     * which hand model to observe explicitly by setting handModel in the Unity editor or 
     * in code.
     * 
     * @since 4.1.2
     */
    public class GetLeapFingers : Detector
    {
        /**
         * The interval at which to check finger state.
         * @since 4.1.2
         */
        [Tooltip("The interval in seconds at which to check this detector's conditions.")]
        [Units("seconds")]
        [MinValue(0)]
        public float Period = .05f; //seconds
        static public float MinFingerToPoleDist;

        /**
         * The HandModelBase instance to observe. 
         * Set automatically if not explicitly set in the editor.
         * @since 4.1.2
         */
        [Tooltip("The hand model to watch. Set automatically if detector is on a hand.")]
        public HandModelBase HandModel = null;

        /** The required thumb state. */
        [Header("Finger States")]
        [Tooltip("Required state of the thumb.")]
        public PointingState Thumb = PointingState.Either;
        /** The required index finger state. */
        [Tooltip("Required state of the index finger.")]
        public PointingState Index = PointingState.Either;
        /** The required middle finger state. */
        [Tooltip("Required state of the middle finger.")]
        public PointingState Middle = PointingState.Either;
        /** The required ring finger state. */
        [Tooltip("Required state of the ring finger.")]
        public PointingState Ring = PointingState.Either;
        /** The required pinky finger state. */
        [Tooltip("Required state of the little finger.")]
        public PointingState Pinky = PointingState.Either;

        /** How many fingers must be extended for the detector to activate. */
        [Header("Min and Max Finger Counts")]
        [Range(0, 5)]
        [Tooltip("The minimum number of fingers extended.")]
        public int MinimumExtendedCount = 0;
        /** The most fingers allowed to be extended for the detector to activate. */
        [Range(0, 5)]
        [Tooltip("The maximum number of fingers extended.")]
        public int MaximumExtendedCount = 5;
        /** Whether to draw the detector's Gizmos for debugging. (Not every detector provides gizmos.)
         * @since 4.1.2 
         */
        [Header("")]
        [Tooltip("Draw this detector's Gizmos, if any. (Gizmos must be on in Unity edtor, too.)")]
        public bool ShowGizmos = true;

        private IEnumerator watcherCoroutine;

        void OnValidate()
        {
            int required = 0, forbidden = 0;
            PointingState[] stateArray = { Thumb, Index, Middle, Ring, Pinky };
            for (int i = 0; i < stateArray.Length; i++)
            {
                var state = stateArray[i];
                switch (state)
                {
                    case PointingState.Extended:
                        required++;
                        break;
                    case PointingState.NotExtended:
                        forbidden++;
                        break;
                    default:
                        break;
                }
                MinimumExtendedCount = Math.Max(required, MinimumExtendedCount);
                MaximumExtendedCount = Math.Min(5 - forbidden, MaximumExtendedCount);
                MaximumExtendedCount = Math.Max(required, MaximumExtendedCount);


            }

        }

        void Awake()
        {
            FindObjectOfType<AudioManager>().Play("A");
            watcherCoroutine = extendedFingerWatcher();
        }

        void OnEnable()
        {
            print("Right Hand Detected");
            StartCoroutine(watcherCoroutine);
        }

        void OnDisable()
        {
            StopCoroutine(watcherCoroutine);
            //print("No Hand");
            Deactivate();

        }

        IEnumerator extendedFingerWatcher()
        {
            Hand hand;
            while (true)
            {
                MinFingerToPoleDist = 0.0f;
                //float MinFingerToPoleDist = 100.0f;
                bool fingerState = false;
                if (HandModel != null && HandModel.IsTracked)
                {
                    hand = HandModel.GetLeapHand();

                    if (hand != null)
                    {
                        /*
                        fingerState = matchFingerState(hand.Fingers[0], Thumb)
                          && matchFingerState(hand.Fingers[1], Index)
                          && matchFingerState(hand.Fingers[2], Middle)
                          && matchFingerState(hand.Fingers[3], Ring)
                          && matchFingerState(hand.Fingers[4], Pinky);

                        int extendedCount = 0;
                        */
                        for (int f = 0; f < 5; f++)
                        {
                            Finger finger = hand.Fingers[f];
                            /*
                            if (finger.IsExtended)
                            {
                                extendedCount++;
                            }
                            */
                            if (hand.IsRight)
                            {
                                //print("right hand");
                                // get finger position
                                //print("getting finger tip position");
                                //print(hand.Fingers[f].TipPosition);
                                float FingerDistToPole = getDistToPole(finger);
                                if (FingerDistToPole > MinFingerToPoleDist)
                                {
                                    MinFingerToPoleDist = FingerDistToPole;
                                    //print(MinFingerToPoleDist);
                                }
                            }
                            else
                            {
                                Finger thumb = hand.Fingers[0];

                                // get finger position
                                //print("left thumb");
                                float FingerDistToBase = getDistToBase(finger);
                                playvolume(FingerDistToBase);
                            }
                        }
                        /*
                        fingerState = fingerState &&
                                     (extendedCount <= MaximumExtendedCount) &&
                                     (extendedCount >= MinimumExtendedCount);

                        if (HandModel.IsTracked && fingerState)
                        {
                            Activate();
                        }
                        else if (!HandModel.IsTracked || !fingerState)
                        {
                            Deactivate();
                        }
                        */

                        if (hand.IsRight)
                        {
                            playpitch(1.2f - MinFingerToPoleDist);
                        }

                    }
                    
                }
                else if (IsActive)
                {
                    Deactivate();
                }
                yield return new WaitForSeconds(Period);

            }
        }

        private bool matchFingerState(Finger finger, PointingState requiredState)
        {
            return (requiredState == PointingState.Either) ||
                   (requiredState == PointingState.Extended && finger.IsExtended) ||
                   (requiredState == PointingState.NotExtended && !finger.IsExtended);
        }

        private float getDistToPole(Finger finger)
        {
            //float xyz[3] = finger.TipPosition;
            // pole is at (x=don't care, y=don't care, z=1.2)
            return finger.TipPosition[2];
        }

        private void playpitch(float MinFingerToPoleDist)
        {
            // new pitch calculation
            // each 0.01m has four half notes, centering "A" pitch at the 15th key

            double step = MinFingerToPoleDist / 0.01f - 15;
            float pitch = (float)( Math.Pow(1.05946, -1f * step) ); //Math.Pow(1.05946, -1f * step);
            //print(step);
            
            //print("pitch"); print(pitch);
            FindObjectOfType<AudioManager>().ChangePitch("A", pitch);

        }
        
        private float getDistToBase(Finger finger)
        {
            //float xyz[3] = finger.TipPosition;
            // pole is at (x=don't care, y=0, z=don'tcare)
            return .3f + finger.TipPosition[1];
        }

        private void playvolume(float FingerDistToBase)
        {
            //print("FingerDistToBase"); print(FingerDistToBase);
            float volume = 8f * FingerDistToBase -0.5f; //(MinFingerToBase + .2f) / .5f ;

            print("volume"); print(volume);
            FindObjectOfType<AudioManager>().ChangeVolume("A", volume);
        }


#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            if (ShowGizmos && HandModel != null && HandModel.IsTracked)
            {
                PointingState[] state = { Thumb, Index, Middle, Ring, Pinky };
                Hand hand = HandModel.GetLeapHand();
                int extendedCount = 0;
                int notExtendedCount = 0;
                for (int f = 0; f < 5; f++)
                {
                    Finger finger = hand.Fingers[f];
                    if (finger.IsExtended) extendedCount++;
                    else notExtendedCount++;
                    if (matchFingerState(finger, state[f]) &&
                       (extendedCount <= MaximumExtendedCount) &&
                       (extendedCount >= MinimumExtendedCount))
                    {
                        Gizmos.color = OnColor;
                    }
                    else
                    {
                        Gizmos.color = OffColor;
                    }
                    Gizmos.DrawWireSphere(finger.TipPosition.ToVector3(), finger.Width);
                    
                }
            }
        }
#endif
    }

    /** Defines the settings for comparing extended finger states */
    public enum PointingState { Extended, NotExtended, Either }
}
