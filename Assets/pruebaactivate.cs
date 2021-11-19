using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaactivate : MonoBehaviour
{
    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        if(btn.activeInHierarchy==false){
            print("El boton de disconnect no esta activado");
        }else{
            print("El boton disconnect esta activado");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
