using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

using brainflow;
using brainflow.math;



    public class SignalFilteringECG: MonoBehaviour
    {
        public static double[,] unprocessed_data;
        public static double[,] empty_data;
        public static double[] filtered5;
        public static double[] filtered12;
        public static double[] filtered19;
        public static double[] filtered25;

        public static String enemySelected;

        //public GameObject textObject;

        public TextMeshProUGUI enSel;
        void Awake(){

            print("SignalFiltering Started");
            DontDestroyOnLoad(this.gameObject);
            //enSel = textObject.GetComponent<TextMeshProUGUI> ();
        }

        void Update ()
        {
            //THIS FUNCTION WAS MAINLY TESTED WITH THE SYNTHETIC BOARD
            int board_id = staticPorts.boardIdSelected;
            //double[,] unprocessed_data = openbciConnection.data;
//            Debug.Log("Num elements SF unprocessed data: " + unprocessed_data.GetLength(1));
            int[] eeg_channels = staticPorts.eeg_channels;
            
            print("Number of EEG channels:  " + eeg_channels.Length);
            
            if (unprocessed_data.GetLength(1) % (staticPorts.sampling_rate) == 0){
                //print("Entering the segmentation loop");
                //print((unprocessed_data.GetRow (eeg_channels[0]), staticPorts.sampling_rate, 15.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0));
                print("ENTERED THE IF");
                print(unprocessed_data.GetRow (eeg_channels[0]));
                print(unprocessed_data.GetRow (eeg_channels[1]));

                enSel.text = Convert.ToString(eeg_channels[2]);
                unprocessed_data = empty_data;
            }
            
            
            
        
        }
    }