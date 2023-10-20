using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToLaser : MonoBehaviour
{
    GameObject player;
    GameObject laser;
    public AudioManager playerAudioManager;
    private void Start() {
        player = GameObject.Find("Player");
        laser = player.transform.Find("Laser").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if(PointManager.instance.points >= 200){
            laser.SetActive(true);
            playerAudioManager.PlayRandomAudioFromSource(7);
            gameObject.SetActive(false);
        }
    }
}
