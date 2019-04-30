using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EventSpawner : MonoBehaviour
{
    private string eventsFileName = "events.json";
    public GameObject dataController;

    public Button btn;
    int counter = 0;
    
    // public DrawPopUp drawer;

    public EventOptions[] LoadJSON(string fileName)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            EventOptions[] loadedData = JsonHelper.FromJson<EventOptions>(dataAsJson);

            return loadedData;
        }

        return null;
    }

    public void RandomEventSpawner()
    {
        if(counter == 0) {
            counter++;
            return;
        }
        var controller = dataController.GetComponent<DataController> ();  
        
        long followers = controller.followers;
        long tribute  = controller.tribute;

        int addValueFollowers = Mathf.RoundToInt(followers * 0.01f);
        int addValueTribute = Mathf.RoundToInt(tribute * 0.02f);
        print(addValueFollowers);
        print(followers);
        // Carrega JSON com eventos

        EventOptions[] events = LoadJSON(eventsFileName);

        int eventsLenght = events.GetLength(0);

        int randomEvent = Random.Range(0, eventsLenght);

        // Seleciona evento randomicamente

        EventOptions selectedEvent = events[randomEvent];

        if (selectedEvent.Operator == "Sub")
        {
            addValueFollowers = addValueFollowers * -1;
            addValueTribute = addValueFollowers * -1;
        }

        if (selectedEvent.Type == "Tribute")
        {
            controller.addTributeSpaw(addValueTribute);

            print(addValueTribute);

        }
        else if (selectedEvent.Type == "Followers")
        {
            controller.addFollowers(addValueFollowers);

            print(addValueFollowers);
        }

        string popUpMessage = System.String.Format(
            "{0}. {1}: {2}.",
            selectedEvent.Text,
            selectedEvent.Type,
            selectedEvent.Operator
        );

        btn.GetComponent<DrawPopUp>().Show(popUpMessage);
    }

    void Start()
    {
        float waitTime = Random.Range(300, 360);
        InvokeRepeating("RandomEventSpawner", 0, waitTime);
    }

}