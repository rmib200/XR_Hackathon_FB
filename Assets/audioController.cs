

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioController : MonoBehaviour
{
    public GameObject audioBtnOn;
    public GameObject audioBtnOff;

    /*Obteniendo los botones de start concentration App y de Start*/

    public GameObject concentrationappstartbtn;
    public GameObject concentrationstartbtn;
    public GameObject concentrationstopbtn;




    // Start is called before the first frame update
    private void Awake() {
        //Muting sound at the start of the game
        PlayerPrefs.SetInt("Muted", 1);
        // print("Muting sound");
    }
    void Start()
    {
        SetSoundState();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ToggleSound(){
        if(PlayerPrefs.GetInt("Muted",0) == 0){
            PlayerPrefs.SetInt("Muted",1);
        }
        else{
            PlayerPrefs.SetInt("Muted", 0);
        }
        SetSoundState();
    }

    private void SetSoundState(){

        if(PlayerPrefs.GetInt("Muted", 0) == 0){
        AudioListener.volume = 1;
        print("Sound On");
        audioBtnOn.SetActive(true);
        audioBtnOff.SetActive(false);
        }
        else{
        AudioListener.volume = 0;
        audioBtnOn.SetActive(false);
        audioBtnOff.SetActive(true);

        }
    }

    /*Usando el Voice SDK...............*/
      /// <param name="values"></param>
    //Seleccionando el tipo de board a usar
    public void TypeApp(string[] values){
        /*Los valores llegan en el orden media,object,function(app,concentration,start)
        por eso las posiciones de la cadena values*/
        var mediaString = values[0];
        Debug.Log(mediaString);
         var objectString = values[1];
        Debug.Log(objectString); 
        var functionString = values[2];
        Debug.Log(functionString); 
    
        if(functionString.Equals("start")){
            if(objectString.Equals("concentration")){
                if(mediaString.Equals("app")){
                   if(concentrationappstartbtn.activeInHierarchy==true){
                    Button btn=concentrationappstartbtn.GetComponent<Button>();
                    btn.onClick.Invoke();
                    if(concentrationstartbtn.activeInHierarchy==true){
                        Button btn2=concentrationstartbtn.GetComponent<Button>();
                        btn2.onClick.Invoke();
                        /*desactivando el boton de start*/
                        concentrationstartbtn.SetActive(false);
                        /*activando el boton de disconnect*/
                        concentrationstopbtn.SetActive(true);
                    }
                   }
                }else{
                    if(mediaString.Equals("music")){
                         if(audioBtnOn.activeInHierarchy==false){
                        Button btn=audioBtnOn.GetComponent<Button>();
                        btn.onClick.Invoke();
                    }
                    }
                }
            }
        }
        

        
    }

      /*Usando el Voice SDK............... para programar la parte de cerrar el concentration app*/
      /// <param name="values"></param>
  
    public void closeTypeApp(string[] values){
        Debug.Log("Entre aqui");
        /*Los valores llegan en el orden media,object,function(app,concentration,start)
        por eso las posiciones de la cadena values*/
        var mediaString = values[0];
        Debug.Log(mediaString);
         var objectString = values[1];
        Debug.Log(objectString); 
        var functionString = values[2];
        Debug.Log(functionString); 


        if(functionString.Equals("stop")){
            if(objectString.Equals("concentration")){
                if(mediaString.Equals("app")){
                   /*si el boton de disconnect se encuentra activado */
                    if(concentrationstopbtn.activeInHierarchy==true){
                        Button btn2=concentrationstopbtn.GetComponent<Button>();
                        btn2.onClick.Invoke();
                        /*Buscando el boton de back para que cuando se de click al disconnect
                        tambien de click al boton de return */
                        GameObject back_btn=GameObject.Find("back_btn");
                        Button back=back_btn.GetComponent<Button>();
                        back.onClick.Invoke();
                    
                   }
                }else{
                    if(mediaString.Equals("music")){
                        if(audioBtnOff.activeInHierarchy==false){
                        Button btn=audioBtnOff.GetComponent<Button>();
                        btn.onClick.Invoke();
                    }
                    }
                }
            }
        }
        

        
    }


}
