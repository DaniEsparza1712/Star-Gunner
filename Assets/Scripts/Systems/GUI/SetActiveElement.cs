using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveElement : MonoBehaviour
{
    public Button selected;
    private void OnEnable() {
        selected.Select();
    }
}
