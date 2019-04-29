using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
	[SerializeField]
	protected Toggle[] toggles;

	private void Awake()
	{
		if (toggles.Length > 0)
		{
			Debug.Log(toggles.Length);
			// for(int i = 0; i < toggles.Length; i++)
			// {
			// 	toggles[i].onValueChanged.AddListener((t) => Debug.Log(toggles[i]));
			// }
		}
	}

	private void OnToggleValueChanged(Toggle toggle, bool newValue)
	{
		if (newValue)
		{
			for (int i = 0; i < toggles.Length; i++)
			{
				if (toggles[i] != toggle)
					toggles[i].isOn = false;
			}
		}
	}
}
