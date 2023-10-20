using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public string scene;

    public void ChargeScene(){
        SceneManager.LoadScene(scene);
    }
    public void Quit(){
        Application.Quit();
    }

}
