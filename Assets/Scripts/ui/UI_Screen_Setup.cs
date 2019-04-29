using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Screen_Setup : UI_Screen
{
	#region Variables
	[Header("Setup Cult Properties")]
	public InputField cultNameInput;
	public InputField hollyBookNameInput;
	public InputField guruNameInput;
	// public GuruData guru { get; private set; }

	static string guruName;

	#endregion

	#region Helpers
	public virtual void SetupGameOptions()
	{

		
		if (guruNameInput.text != null || guruNameInput.text != "")
		{
			PlayerPrefs.SetString("GuruName", guruNameInput.text);
		}
		if (hollyBookNameInput.text != null || hollyBookNameInput.text != "")
		{
			PlayerPrefs.SetString("HollyBookName", hollyBookNameInput.text);
		}
		if (cultNameInput.text != null || cultNameInput.text != "")
		{
			PlayerPrefs.SetString("CultName", cultNameInput.text);
		}
	}


	#endregion
}
