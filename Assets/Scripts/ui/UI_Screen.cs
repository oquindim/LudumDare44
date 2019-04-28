using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CanvasGroup))]
public class UI_Screen : MonoBehaviour
{
#region Variables
[Header("Main Properties")]
public Selectable u_StartSelectable;

[Header("Screen Events")]
public UnityEvent onScreenStart = new UnityEvent();
public UnityEvent onScreenClose = new UnityEvent();
private Animator animator;
#endregion
// Start is called before the first frame update
void Start()
{
	animator = GetComponent<Animator>();

	if (u_StartSelectable)
	{
		EventSystem.current.SetSelectedGameObject(u_StartSelectable.gameObject);
	}

}

#region Helpers
public virtual void StartScreen()
{
	if (onScreenStart != null)
	{
		onScreenStart.Invoke();
	}
	HandleAnimator("OpenScreen");
}
public virtual void CloseScreen()
{
	if (onScreenClose != null)
	{
	onScreenClose.Invoke();
	}
	HandleAnimator("CloseScreen");
}
void HandleAnimator(string uTrigger)
{
	if (animator)
	{
		animator.SetTrigger(uTrigger);
	} else {
	  animator = GetComponent<Animator>();
	  animator.SetTrigger(uTrigger);
	}
}
#endregion
}
