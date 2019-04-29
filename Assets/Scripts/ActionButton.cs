using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    // Start is called before the first frame update

    public string text;
    Text label;
    Button btn;
    Slider progressSpeaker;
    public float delay;
    public int toIncrease;
    public bool avaiable;
    void Start() {
        btn = GetComponent<Button>();
        label = btn.GetComponentInChildren<Text>();
        progressSpeaker = btn.GetComponentInChildren<Slider>();
        label.text = text;
    }

    public void blockButton() {StartCoroutine(Progress());}
    public float getDelay() {return delay;}
    public void setDelay(float input) {delay = input;}
    public string getText() {return text;}
    public void setText(string input) {text = input;}

    // calculate the transition on progress bar 
    IEnumerator Progress()
    {
        float timer = 0;
        btn.interactable = false;
        while (timer < delay)
        {   
            timer += 0.02f;
            progressSpeaker.value = timer / delay;

            if (timer >= delay) {
                progressSpeaker.value = 0;
                btn.interactable = true;
            }
            yield return new WaitForSeconds(0.02f);
        }
    }

}
