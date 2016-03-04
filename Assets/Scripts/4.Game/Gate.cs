using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class Gate : MonoBehaviour
{
	float speed = 10.0f;
	float rotateSpeed;

	void Start()
	{
		rotateSpeed = Random.Range(-100, 100);
		transform.localScale = Vector3.zero;
	}
	
	void Update()
	{
		transform.Translate(0, 0, -speed * Time.deltaTime);
		transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
		transform.localScale += (Vector3.one - transform.localScale) * Time.deltaTime * 0.4f;
	}

	public void OnActivate()
	{
		ParticleSystem m_System = GetComponent<ParticleSystem>();
		ParticleSystem.Particle[] m_Particles = new ParticleSystem.Particle[m_System.particleCount];
		int numParticlesAlive = m_System.GetParticles(m_Particles);

		for (int i = 0; i < numParticlesAlive; i++)
		{
			m_Particles[i].startColor = Color.green;
			m_Particles[i].startSize *= 2.0f;
		}

		m_System.SetParticles(m_Particles, numParticlesAlive);
		rotateSpeed = 500f;
	}
}
