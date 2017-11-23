using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	[SerializeField]
	private float currentHealth;
	[SerializeField]
	private float maxHealth;
	private Animator anim;
	private Rigidbody2D rb2d;
	[SerializeField]
	private bool isDead;
	private EnemyPatrolScript enemy;
	[SerializeField] 
	private GameObject[] lootdrop;
	[SerializeField]
	private Transform lootDropLocation;
	private bool lootDropped;


	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		enemy = GetComponent<EnemyPatrolScript> ();
	}

	void Update()
	{
		if (currentHealth <= 0) 
		{
			isDead = true;
			enemy.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			anim.SetTrigger ("Dead");
			if (lootdrop != null) 
			{
				if (!lootDropped) 
				{
					Instantiate (lootdrop [Random.Range (0, lootdrop.Length)], transform.position, transform.rotation);
					lootDropped = true;
				}
			}
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Projectile") 
		{
			if (!isDead) 
			{
				HurtEnemy (1);
				PushEnemy ();
			}
				Destroy (other.gameObject);
		}
	}


	void HurtEnemy(float damage)
	{
		currentHealth -= damage;
		anim.SetTrigger ("Hurt");
	}

	public void HealthEnemy(int healingAmount)
	{
		currentHealth += healingAmount;
	}

	void PushEnemy()
	{
		rb2d.velocity = new Vector2 (-1f, 1.5f);
	}
		
}
