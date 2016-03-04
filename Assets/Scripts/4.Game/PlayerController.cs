using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[SerializeField] Transform playerBody;
	public float speed = 0.1f;
	public bool xAxisOnly = true;
	Vector3 playerTarget;
	bool isAlive = true;

	void Start()
	{
		playerTarget = transform.position;
	}

	void Update()
	{
		if(!isAlive) return;

		var horizontal = Input.GetAxis("Horizontal");
		var vertical = xAxisOnly ? 0 : Input.GetAxis("Vertical");
		playerTarget.Set(horizontal, vertical, 0);
		transform.localPosition += playerTarget * speed;
		transform.localEulerAngles = new Vector3(vertical * -30f, 0, horizontal * -40f);
	}

	public void OnDamage()
	{
		//isAlive = false;
	}
}
