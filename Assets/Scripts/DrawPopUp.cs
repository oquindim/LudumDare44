using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DrawPopUp : MonoBehaviour
{
    Text label;
    Button btn;

    public bool visible;

    public string text;

    void Start() {
        btn = GetComponent<Button>();
        label = btn.GetComponentInChildren<Text>();
        label.text = text;
        
        btn.gameObject.SetActive(visible);
    }

    public void SetVisible(bool state)
    {
        visible = state;
        btn.gameObject.SetActive(visible);
    }

    public void Hide()
    {
        SetVisible(false);
    }

    public void SetText(string message)
    {
        text = message;
        label.text = message;
    }

    public void Show(string message)
    {
        SetVisible(true);

        SetText(message);
    }

}
