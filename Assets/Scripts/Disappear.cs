using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    private bool dissolving;
    private bool startDissolve;
    [HideInInspector] public bool dissolve;
    public float dissolveRate;
    public Material material;
    public AudioSource audioSource;
    public AudioClip dissolveAudio;

    private void Start() {
        dissolving = false;
        startDissolve = false;
        dissolve = false;

        material.SetFloat("_Cutoff", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!dissolving && startDissolve){
            StartDissolve();
        }
    }
    public void StartDissolve(){
        if(dissolve){
            startDissolve = true;
            StartCoroutine("DissolveCoroutine");
        }
    }
    IEnumerator DissolveCoroutine(){
        dissolving = true;
        audioSource.PlayOneShot(dissolveAudio);
        while(material.GetFloat("_Cutoff") < 1){
            float cutOff = material.GetFloat("_Cutoff");
            yield return new WaitForSeconds(dissolveRate);
            material.SetFloat("_Cutoff", cutOff + 0.01f);
        }
    }
}
