using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Screen_Timed : UI_Screen
{
	#region Variables
	[Header("Time Screen Properties")]
	public float u_ScreenTime = 2f;
	public UnityEvent onTimeCompleted = new UnityEvent();

	private float startTime;
	#endregion

	#region Helpers
	public override void StartScreen()
	{
		base.StartScreen();


		startTime = Time.timeScale;
		StartCoroutine(WaitForTime());
	}

	IEnumerator WaitForTime()
	{
		yield return new WaitForSeconds(u_ScreenTime);

		if (onTimeCompleted != null)
		{
			onTimeCompleted.Invoke();
		}
	}
	#endregion
}
