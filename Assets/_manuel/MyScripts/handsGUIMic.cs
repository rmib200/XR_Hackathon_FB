using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class handsGUIMic : MonoBehaviour
{

/*en esta parte primeramente se actualiza el texto y el segundo game 
object sirve para obtener el boton de voice*/
    public GameObject texto;

    public GameObject btn_voice;


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
        Text texte=texto.GetComponent<Text>();
        texte.text="Selecciono el microfono...";

        Button button=btn_voice.GetComponent<Button>();
        button.onClick.Invoke();
        texte.text="Comenzando a oir";
 
    }
    void OnCollisionEnter(Collision collision){
        Button button=btn_voice.GetComponent<Button>();
        Text texte=texto.GetComponent<Text>();
        if(collision.gameObject.name=="index_ui"){
            texte.text="Selecciono el microfono";
            button.onClick.Invoke();
        }
    }
}
