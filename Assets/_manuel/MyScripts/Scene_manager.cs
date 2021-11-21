using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Scene_manager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject boardMenu;
    public GameObject concentrationEEGMenu;
    public GameObject connectButton;
    public GameObject disconnectButton;
    public GameObject concentrationAppButton;
    public void StartGame(){
        SceneManager.LoadScene("base_level_scene");
    }
    public void DebugScene(){
        SceneManager.LoadScene("SSVEPDebugTool");
    }
    public void MultiplayerGame(){
        SceneManager.LoadScene("multiplayer_level");
    }
    public void QuitGame(){
        Application.Quit();
    }

    public void ChangeMenu(){
        if(mainMenu.activeSelf == true){
            mainMenu.SetActive(false);
            
            boardMenu.SetActive(true);

            if(staticPorts.statusON==true){ //Board is turned ON
                connectButton.SetActive(false);
                disconnectButton.SetActive(true);
                concentrationAppButton.SetActive(true);
                print("Board is connected!");
            }else{
                connectButton.SetActive(true);
                disconnectButton.SetActive(false);
                concentrationAppButton.SetActive(false);

            }

        }else if(mainMenu.activeSelf == false){
            mainMenu.SetActive(true);
            boardMenu.SetActive(false);
        }
    }


    public void ConcentrationAppMenuBackButton(){
        if(concentrationEEGMenu.activeSelf) //Turn off menu eeg concentration
        {
            concentrationEEGMenu.SetActive(false);
            boardMenu.SetActive(true);
        }else{                          //Turn on menu eeg concentration
            concentrationEEGMenu.SetActive(true);
            boardMenu.SetActive(false);
        }

    }
    private void Update() {
        ///toggle connect/disconnect button and concentration app button
        if(staticPorts.statusON == true){
            concentrationAppButton.SetActive(true);
        }
        else{
            concentrationAppButton.SetActive(false);
            connectButton.SetActive(true);
            disconnectButton.SetActive(false);
        }
    }
}
