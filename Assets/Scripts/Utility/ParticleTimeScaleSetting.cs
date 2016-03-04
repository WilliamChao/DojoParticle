using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleTimeScaleSetting : MonoBehaviour
{
	float lastTime;
	ParticleSystem particle;

	private void Awake()
	{
		particle = GetComponent<ParticleSystem>();
	}

	void Start ()
	{
		lastTime = Time.realtimeSinceStartup;
	}

	void Update () 
	{

		float deltaTime = Time.realtimeSinceStartup - (float)lastTime;

		particle.Simulate(deltaTime, true, false);

		lastTime = Time.realtimeSinceStartup;
	}
}