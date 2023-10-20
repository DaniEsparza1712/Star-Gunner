using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
    public VideoPlayer bossVideo;
    public GUIManager gUIManager;
    public Camera mainCamera;
    public GameObject player;
    private void Start() {
        bossVideo.Prepare();
        gameObject.SetActive(false);
    }
    private void Update() {
        bossVideo.loopPointReached += EndReached;
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        mainCamera.enabled = true;
        gUIManager.ShowHUD();
        player.SetActive(true);
        gameObject.SetActive(false);
    }
}
