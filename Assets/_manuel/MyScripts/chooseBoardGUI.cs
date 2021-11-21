
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using brainflow;
using UnityEngine.UI;
public class chooseBoardGUI : MonoBehaviour
{   
    /*Llamando a todos los botones*/
    public GameObject button;
    public GameObject btnCython;
    public GameObject btnGanglion;
    public GameObject btnSynthetic;

    /*oyendo la salida que oye el microfono*/
    public Text salida;

    public void Onclick(){
           Button btn=button.GetComponent<Button>();
           btn.onClick.Invoke();
    }    
    //first cython
    //second ganglion

    /*Este parametro es para obtener los valores del audio que devuelve wit.ai*/
    /// <param name="values"></param>
    //Seleccionando el tipo de board a usar
    public void TypeBoard(string[] values){
        Debug.Log("Entre aqui");
        /*Los valores llegan en el orden function(start) y object(first,second...etc) 
        por eso las posiciones de la cadena values*/
        var functionString = values[0];
        Debug.Log(functionString);
         var objectString = values[1];
        Debug.Log(objectString); 
        salida.text=functionString+"     "+objectString;
        /*En caso  de que la funcion sea Start ingresa al fin y dependiendo del 
        object(first, second...) entra a uno de esos*/
        if(functionString.Equals("start")){
            if(objectString.Equals("first")){
                cytonOnClick();
                cytonselected();
            }
            if(objectString.Equals("second")){
                ganglionOnClick();
                ganglionselected();

            }
            if(objectString.Equals("third") || objectString.Equals("three")){
                syntheticOnClick();
                syntheticselected();
            }
        }
    }

/*----------------------------------------------------CYTHONNNNNNNN--------------------------------------------------------------------------------------------*/
    public void cytonOnClick()
    { 
        staticPorts.boardIdSelected = (int)BoardIds.CYTON_BOARD;
        print("Cython");

       /* Button btn=button.GetComponent<Button>();
        btn.onClick.Invoke();*/
    }
    /*Para ser seleccionado mediante la voz el boton Cyton se selecciona el boton y se pone Select
    para que el boton utilize esa funcion que hace que brille*/
    /*Al tener el boton de cython, synthetic...etc seleccionado entonces se selecciona el boton Connect
    Y lo mismo con cualquiera de los botones*/
    public void cytonselected(){
        Button btnn=btnCython.GetComponent<Button>();
        btnn.onClick.AddListener(TaskOnClick);
        btnn.Select();
        Button btn=button.GetComponent<Button>();
        btn.onClick.Invoke();
        
    }
    void TaskOnClick(){
        Debug.Log("CLICK");
    }



/*----------------------------------------------------GANGLIOOOOONNN--------------------------------------------------------------------------------------------*/
     public void ganglionOnClick()
    {
   
        staticPorts.boardIdSelected = (int)BoardIds.GANGLION_BOARD;
        print("Ganglion");

      /*  Button btn=button.GetComponent<Button>();
        btn.onClick.Invoke();*/
    }
       /*Para ser seleccionado mediante la voz*/
       
    public void ganglionselected(){
        Button btnn=btnGanglion.GetComponent<Button>();
        btnn.onClick.AddListener(TaskOnClick);
        btnn.Select();
        Button btn=button.GetComponent<Button>();
        btn.onClick.Invoke();
    }


/*----------------------------------------------------SYNTHETICCCCCCCCCC--------------------------------------------------------------------------------------------*/
     public void syntheticOnClick()
    {
        
        staticPorts.boardIdSelected = (int)BoardIds.SYNTHETIC_BOARD;
        staticPorts.synthetic = true;
        print("Synthetic");
   
       /* Button btn=button.GetComponent<Button>();
        btn.onClick.Invoke();*/
    }
       /*Para ser seleccionado mediante la voz*/
   public void syntheticselected(){
        Button btnn=btnSynthetic.GetComponent<Button>();
        btnn.onClick.AddListener(TaskOnClick);
        btnn.Select();
        Button btn=button.GetComponent<Button>();
        btn.onClick.Invoke();
    }

}
