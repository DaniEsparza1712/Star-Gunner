using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport : MonoBehaviour
{
    public GameObject level;
    public GUIManager gUIManager;
    public GameObject cutsceneCamera;
    public GameObject player;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Camera.main.enabled = false;
            cutsceneCamera.SetActive(true);
            player.SetActive(false);
            gUIManager.HideHUD();
            level.SetActive(false);
            SceneManager.LoadSceneAsync("BossLevel1", LoadSceneMode.Additive);
        }
    }
}
