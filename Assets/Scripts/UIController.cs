using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {


	public Image signalStrengthBack, signalStrengthFront;
	public Text reqResource, timeTilResc,resAmount;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	

	public void UpdateSignalStrength(float strength)
	{
		signalStrengthFront.fillAmount = strength;
	}
	public void UpdateRequiredResource(int req)
	{
		reqResource.text = req + " for new relaytower";
	}
	public void UpdateTimeTilResc(int time)
	{
		timeTilResc.text = "Days until rescue\n" + time;
	}
	public void UpdateResAmount(int amount)
	{
		resAmount.text = "Resources collected:\n" + amount;
	}
}
