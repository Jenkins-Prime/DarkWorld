using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {

	[SerializeField]
	private Text currencyText;
	[SerializeField] 
	private Text textShadow;
	[SerializeField]
	private int currency;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		textShadow.text = currencyText.text;
		currencyText.text = "" + currency;
	}

	public void AddCurrency(int currencyWorth)
	{
		currency += currencyWorth;
	}
}
