using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerEx : EventTrigger
{	
	public bool pressing;
	public bool click = false;

	public override void OnPointerClick( PointerEventData data )
	{
		click = true;
	}
	public override void OnPointerDown( PointerEventData data )
	{
		pressing = true;
	}

	public override void OnPointerUp( PointerEventData data )
	{
		pressing = false;
		click = false;
	}
}