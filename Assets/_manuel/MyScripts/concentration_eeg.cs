using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using brainflow;
using brainflow.math;
using System;
public class concentration_eeg : MonoBehaviour
{

    public void ConcentrationEEG(double[,] data){
            int nfft = DataFilter.get_nearest_power_of_two(staticPorts.sampling_rate);
            print("data static ports:"+data);
            Tuple<double[], double[]> bands = DataFilter.get_avg_band_powers (data, staticPorts.eeg_channels, staticPorts.sampling_rate, true);
            double[] feature_vector = bands.Item1.Concatenate (bands.Item2);
            BrainFlowModelParams model_params = new BrainFlowModelParams ((int)BrainFlowMetrics.CONCENTRATION, (int)BrainFlowClassifiers.REGRESSION);
            MLModel concentration = new MLModel (model_params);
            concentration.prepare ();
            Console.WriteLine ("Concentration: " + concentration.predict (feature_vector));
            concentration.release ();
    }
}
