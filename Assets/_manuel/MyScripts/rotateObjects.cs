using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObjects : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(staticPorts.statusON == false){
            transform.Rotate(Vector3.up * staticPorts.concentrationLvl* 0 * Time.deltaTime);
        }
        else{
         transform.Rotate(Vector3.up * staticPorts.concentrationLvl* rotationSpeed * Time.deltaTime);
        }

    }
}
