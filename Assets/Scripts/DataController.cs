﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour
{
    // Attributes
	public Button prefab;
    public int followers = 0; // number of Followers
    public int level = 1; // Actual level
    public int tribute = 0; // total of tributes
    public float speakDelay = 0.5f; // total in sec to press button speak
    public float widouthInteraction = 0; // total time widouth an interaction
    public int preacher = 1;
    public int pull = 0;

    public GameObject temple;
    public Button speakButton;
    public Text fol;
    public Text tributeLabel;
	public GameObject Buttons;
	Powerups[] els;
    private string gameDataFileName = "powerups.json";

	int nextButton = 50;
	int stats = 0;

    public Powerups[] LoadJSON()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            Powerups[] loadedData = JsonHelper.FromJson<Powerups>(dataAsJson);

            return loadedData;
        }

        return null;
    }


    void Start (){
       InvokeRepeating("increasetribute", 0, 5f);
	   els = LoadJSON();
    }
    private void increasetribute(){
        tribute += followers;
        tributeLabel.text = "$" + tribute.ToString();
	   
    }

    private void decreaseFollowers(){
        float spent = widouthInteraction - Time.deltaTime;
        if(spent > 100) {
            followers -= 5;
            fol.text = followers.ToString();
            widouthInteraction = Time.deltaTime;
        }
    }

    // Start is called before the first frame update
    public void increaseFollowers () {
        int rand =  Random.Range(-3,10);
        pull = rand;
        if(followers == 0 && rand < 0){  rand = 0;}
        temple.GetComponent <AtraiSeguidor>().ReceiveUIInput(rand);
        speakButton.GetComponent<ActionButton>().blockButton();
    }
	public void addTribute(int value)
	{
		tribute += value;
        tributeLabel.text = "$" + tribute.ToString();
	}

	public void addFollowers(int value)
	{
		followers += value;
		fol.text = followers.ToString();

		if(followers >= nextButton) {
			Button objetoGerado = Instantiate(prefab);
			objetoGerado.transform.SetParent(Buttons.transform, false);
			nextButton += nextButton;
			objetoGerado.GetComponent<ActionButton>().setText(els[stats].Name);
			stats+=1;
		}
		
	}
	public void removeFollowers(int value)
	{
		followers -= value;
		fol.text = followers.ToString();
	}

    public void remove() {
        pull--;
    }
    public void add() {
        pull++;
    }
}
