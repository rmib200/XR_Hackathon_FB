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


    /*Contador para apagar el microfono y un flag */
    public float timeRemaining=0;
    public bool btn_touched_flag=false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(btn_touched_flag==true){
           if(timeRemaining>0){
                timeRemaining -= Time.deltaTime;
           }else{
                Text texte=texto.GetComponent<Text>();
                texte.text="Counter End...";
                btn_touched_flag=false;
           }
        }
    }

/*Detecta si el microfono de la mano izquierda choco con el dedo de la derecha
esto se comprueba con el objeto "index_ui", tambien para evitar que el microfono sea
seleccionado varias veces comprueba que hayan pasado 4 segundos desde que fue seleccionado*/
    public void OnTriggerEnter(Collider other) {

        if(btn_touched_flag==false){
            if(other.gameObject.name=="index_ui"){
                    Button button=btn_voice.GetComponent<Button>();
                    button.onClick.Invoke();
                    btn_touched_flag=true;
                    timeRemaining=4;
                    Text texte=texto.GetComponent<Text>();
                    texte.text="Counter Activate...";
            }
        }else{
            return;
        }
        
 
    }


}
