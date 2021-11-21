using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handsGUIMic : MonoBehaviour
{
    public GameObject particleEffectUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "index_ui")
        print("Hands GUI Mic is ON");
         var rotation = new Quaternion();
        // rotation.eulerAngles = new Vector3(transform.localRotation.x+90f, transform.localRotation.y, transform.localRotation.z);
        rotation.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z+90f);
        // Instantiate(particleEffectUI, transform.position, transform.localRotation);
        // Instantiate(particleEffectUI, transform.position, transform.rotation);
        Quaternion newRotation = Quaternion.LookRotation(Vector3.up);
        Instantiate(particleEffectUI, transform.position, Quaternion.identity);
    }
}
