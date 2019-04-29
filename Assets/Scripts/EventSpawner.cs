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

        int addValue = 0;

        // object events = EventOptions.CreateFromJSON(options);

        // Carrega JSON com eventos
        EventOptions[] events = LoadJSON(eventsFileName);

        int eventsLenght = events.GetLength(0);

        int randomEvent = Random.Range(0, eventsLenght);

        // Seleciona evento randomicamente
        // TODO: passar valores para %
        EventOptions selectedEvent = events[3];

        if (selectedEvent.Operator == "Add")
        {
            addValue = Random.Range(0, 100);

        } else
        {
            addValue = Random.Range(-50, -1);
        }

        if (selectedEvent.Type == "Tribute")
        {
            controller.addTribute(addValue);

        } else if (selectedEvent.Type == "Followers")
        {
            controller.addFollowers(addValue);
        }

        string popUpMessage = System.String.Format(
            "{0}. {1}: {2}",
            selectedEvent.Text,
            selectedEvent.Type,
            addValue
        );

        btn.GetComponent<DrawPopUp>().Show(popUpMessage);
    }

    void Start()
    {
        float waitTime = Random.Range(300, 360);
        InvokeRepeating("RandomEventSpawner", 0, waitTime);
    }

}