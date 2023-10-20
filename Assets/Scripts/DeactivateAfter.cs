using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfter : MonoBehaviour
{
    public float lifeTime;
    private void OnEnable() {
        StartCoroutine("Disappear");    
    }

    IEnumerator Disappear(){
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
}
