using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EventSpawner : MonoBehaviour
{
    private string gameDataFileName = "events.json";
    public GameObject dataController;

    public bool cooldown = false;

    public EventOptions[] LoadJSON()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            EventOptions[] loadedData = JsonHelper.FromJson<EventOptions>(dataAsJson);

            return loadedData;
        }

        return null;
    }

    IEnumerator Example()
	{
		float timer = 0;

		while (timer < 10)
		{
			timer += 0.02f;

			if (timer >= 10) {
                cooldown = true;
			}
			yield return new WaitForSeconds(0.02f);
		}
	}
 
    private void RandomEventSpawner()
    {
        var controller = dataController.GetComponent<DataController>();  
        
        int followers = controller.followers;
        int tribute  = controller.tribute;

        int addValue = 0;

        float randomEventCooldown = Random.Range(5, 10);

        // object events = EventOptions.CreateFromJSON(options);

        // Carrega JSON com eventos
        EventOptions[] events = LoadJSON();

        int eventsLenght = events.GetLength(0);

        int randomEvent = Random.Range(0, eventsLenght);

        // Seleciona evento randomicamente
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

        print(System.String.Format(
            "Operator: {0} - Text: {1} - Value: {2}",
            selectedEvent.Operator,
            selectedEvent.Text,
            addValue
            )
        );

    }

    void Start()
    {
        float waitTime = Random.Range(180, 300);
        InvokeRepeating("RandomEventSpawner", 0, waitTime);
    }

}