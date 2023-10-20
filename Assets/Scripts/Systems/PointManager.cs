using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public static PointManager instance;
    [HideInInspector]
    public int points;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        PointManager.instance = new PointManager();

        PointManager.instance.points = 0;
        PointManager.instance.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        PointManager.instance.text.text = PointManager.instance.points.ToString();
        if(Input.GetKeyDown(KeyCode.Space)){
            PointManager.instance.points = 200;
        }
    }
    public void PickUpPoints(int pickedPoints){
        PointManager.instance.points += pickedPoints;
    }
}
