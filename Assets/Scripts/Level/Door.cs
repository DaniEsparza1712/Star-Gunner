using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int pointsKey;
    [SerializeField] private float vanishTime;
    private bool startedVanish = false;
    public Material material;
    private void Start() {
        material.SetFloat("_FresnelPower", 7);
    }
    // Update is called once per frame
    void Update()
    {
        if(pointsKey <= PointManager.instance.points && !startedVanish){
            StartCoroutine("Vanish", vanishTime);
        }
    }
    IEnumerator Vanish(float waitTime){
        startedVanish = true;
        while(material.GetFloat("_FresnelPower") > 0){
            float fresnel = material.GetFloat("_FresnelPower");
            material.SetFloat("_FresnelPower", fresnel - 0.1f);

            yield return new WaitForSeconds(waitTime);
        }
        Destroy(gameObject);
    }
}
