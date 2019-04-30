using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGuruUI : MonoBehaviour
{
    public InputField inputText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetupGuru (int tipo) {
		PlayerPrefs.SetInt("GuruType", tipo);
	}

    public void SetupStringInput (string tipo) {
        string nome = inputText.text;
		PlayerPrefs.SetString(tipo, nome);
	}
}
