using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButton : MonoBehaviour
{
    // Start is called before the first frame update

    public string text;
    Text label;
    Button btn;

    void Start() {
        btn = GetComponent<Button>();
        label = btn.GetComponentInChildren<Text>();
        label.text = text;
    }
}
