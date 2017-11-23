using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

	[SerializeField]
	private GameObject collectionGraphic;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Instantiate (collectionGraphic, other.transform.position, other.transform.rotation);
			FindObjectOfType<CurrencyManager> ().AddCurrency (5);
			Destroy (this.gameObject);
		}
	}
}
