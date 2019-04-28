using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UI_System : MonoBehaviour
{
	#region Variables
	[Header("Main Properties")]
	public UI_Screen u_startScreen;
	[Header("System Events")]
	public UnityEvent onSwitchScreen = new UnityEvent();

	[Header("Fader Properties")]
	public Image u_Fader;
	public float u_FadeInDuration = 1f;
	public float u_FadeOutDuration = 1f;

	private Component[] screens = new Component[0];
	private UI_Screen previousScreen;
	public UI_Screen PreviousScreen { get { return previousScreen; } }
	private UI_Screen currentScreen;
	public UI_Screen CurrentScreen { get { return currentScreen; } }
	#endregion
	#region Main
	// Start is called before the first frame update
	void Start()
	{
		screens = GetComponentsInChildren<UI_Screen>(true);
		InitializeScreens();
		if (u_startScreen)
		{
			SwitchScreens(u_startScreen);
		}
		if (u_Fader)
		{
			u_Fader.gameObject.SetActive(true);
			FadeIn();
		}
	}
	#endregion

	#region Helpers
	public void SwitchScreens(UI_Screen uiScreen)
	{
		if (uiScreen)
		{
			if (currentScreen)
			{
				currentScreen.CloseScreen();
				previousScreen = currentScreen;
			}
			currentScreen = uiScreen;
			currentScreen.StartScreen();
			if (onSwitchScreen != null)
			{
				onSwitchScreen.Invoke();
			}
		}
	}

	public void FadeIn()
	{
		if (u_Fader)
		{
			u_Fader.CrossFadeAlpha(0f, u_FadeInDuration, true);
		}
	}
	public void FadeOut()
	{
		if (u_Fader)
		{
			u_Fader.CrossFadeAlpha(1f, u_FadeOutDuration, true);
		}
	}
	public void GoToPreviousScreen()
	{
		if (previousScreen)
		{
			SwitchScreens(previousScreen);
		}
	}
	public void LoadScene(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}
	void InitializeScreens()
		{
		foreach (var screen in screens)
		{
			screen.gameObject.SetActive(true);
		}
	}
	#endregion
}
