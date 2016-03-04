using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour
{
	[SerializeField] ParticleSystem explosion;

	void Start ()
	{
	
	}

	void OnTriggerEnter (Collider c)
	{
		if (c.CompareTag("Item")) {
			
			c.SendMessage("OnActivate", SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnParticleCollision(GameObject target)
	{
		if (target.CompareTag("Enemy")) {

			SendMessage("OnDamage", SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnDamage()
	{
		if(explosion)
		{
			explosion.Play();
		}
	}
}
