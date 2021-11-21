using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillConcentrationRing : MonoBehaviour
{
    public Image ring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        concentrationFiller();
    }
     public void concentrationFiller()
    {
        if (openbciConnection.concentrationAppRun == true)
        {
            ring.fillAmount = Mathf.Lerp(ring.fillAmount, staticPorts.concentrationLvl, 3f * Time.deltaTime);
        }
        // if (gameStartClass.bp == true)
        // {
        //     ring.fillAmount = Mathf.Lerp(ring.fillAmount, concentrationClass.band_power, 3f * Time.deltaTime);
        // }

    }
}
