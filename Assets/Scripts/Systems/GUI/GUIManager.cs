using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public GameObject hud;
    public GameObject gameOver;
    public void ChangeToGameOver(){
        hud.SetActive(false);
        gameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void HideHUD(){
        hud.SetActive(false);
    }
    public void ShowHUD(){
        hud.SetActive(true);
    }
}
