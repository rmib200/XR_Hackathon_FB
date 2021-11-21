using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

using brainflow;
using brainflow.math;



    public class SignalFiltering: MonoBehaviour
    {
        public static double[,] unprocessed_data = null;
        public static double[,] empty_data;

        public static double [] filtered;
        /*
        public static double[] filtered5;
        public static double[] filtered12;
        public static double[] filtered19;
        public static double[] filtered25;
        */
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
            if(unprocessed_data!=null){
                //THIS FUNCTION WAS MAINLY TESTED WITH THE SYNTHETIC BOARD
                int board_id = staticPorts.boardIdSelected;
                
                int[] eeg_channels = staticPorts.eeg_channels;
                
                
                if (unprocessed_data.GetLength(1) % (staticPorts.sampling_rate*2) == 0){
                    
                    print("ENTERED THE FILTERING IF");
                    for (int i = 0; i < eeg_channels.Length; i++){
                        
                        //FILTERING THE SIGNAL WITH NOTCH AND BANDPASS FILTER
                        filtered = DataFilter.remove_environmental_noise(unprocessed_data.GetRow (eeg_channels[i]),staticPorts.sampling_rate,(int)NoiseTypes.FIFTY);
                        filtered = DataFilter.perform_bandpass(unprocessed_data.GetRow(eeg_channels[i]),staticPorts.sampling_rate,10.0,3.0,2,(int)FilterTypes.BUTTERWORTH, 0.0);
                        
                    }
                    print(filtered.GetLength(0));
                }
            

                
                unprocessed_data = empty_data;
            }
            
            
            
        
        }
    }