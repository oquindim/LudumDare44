using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour
{
	// Attributes
	public int followers = 0; // number of Followers
	public int level = 1; // Actual level
	public int tribute = 0; // total of tributes
	public float speakDelay = 0.5f; // total in sec to press button speak
	public float widouthInteraction = 0; // total time widouth an interaction

	public int preacher = 1;
	public int pull = 0;


	// References
	public Button speakButton;
	public Slider progressSpeaker;
	public Text fol;
	public Text tributeLabel;

	void Start (){
	   widouthInteraction = Time.deltaTime;
	   InvokeRepeating("increasetribute", 0, 5f);
	//    InvokeRepeating("decreaseFollowers", 0, 3f);
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
		if(followers == 0 && rand < 0){
			rand = 0;
		}
		float tm1 = Time.deltaTime;
		StartCoroutine(Example());
		followers+= rand;
		fol.text = followers.ToString();
	}
	public void remove() {
		pull--;
	}
	public void add() {
		pull++;
	}

	IEnumerator Example()
	{
		float timer = 0;
		speakButton.interactable = false;

		while (timer < speakDelay)
		{
			timer += 0.02f;
			progressSpeaker.value = timer / speakDelay;

			if (timer >= speakDelay) {
				progressSpeaker.value = 0;
				speakButton.interactable = true;
			}
			yield return new WaitForSeconds(0.02f);
		}
	}
}
