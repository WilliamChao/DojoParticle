using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class PerlinNoiseController : MonoBehaviour
{
	[Range(0f, 2f)] public float m_strength = 1f;
	[Range(0f, 2f)] public float m_turbulence = 1f;
	[Range(0f, 1f)] public float m_frequency = 0.1f;
	[Range(-180f, 180f)] public float m_rotateSpeed = 0f;
	[Range(0f, 100f)] public float m_waveSize = 50f;
	[Range(0f, 1f)] public float m_randomForce = 0f;
	[Range(1, 5)] int m_fractalLevel = 1;

	ParticleSystem ps;
	ParticleSystem.ForceOverLifetimeModule forceOverLifetime;
	ParticleSystem.Particle[] m_Particles;

	void Start ()
	{
		ps = GetComponent<ParticleSystem>();
		forceOverLifetime = ps.forceOverLifetime;
		forceOverLifetime.enabled = true;
		forceOverLifetime.space = ParticleSystemSimulationSpace.World;
		forceOverLifetime.randomized = false;
	}
	
	void LateUpdate ()
	{
		float scale = 1 / m_waveSize;

		if(ps.particleCount <= 0)
		{
			return;
		}

		ParticleSystem.MinMaxCurve curve = new ParticleSystem.MinMaxCurve(-m_randomForce, m_randomForce);
		forceOverLifetime.x = forceOverLifetime.y = forceOverLifetime.z = curve;

		m_Particles = new ParticleSystem.Particle[ps.particleCount];
		int numParticlesAlive = ps.GetParticles(m_Particles);

		for (int i = 0; i < numParticlesAlive; i++)
		{
			m_Particles[i].position += m_Particles[i].position * Time.deltaTime * m_turbulence * (Perlin.Fbm(
				m_Particles[i].position.x * scale, 
				m_Particles[i].position.y * scale + Time.time * m_frequency, 
				m_Particles[i].position.z * scale, 
				m_fractalLevel)
			) * m_strength;
		}

		ps.SetParticles(m_Particles, numParticlesAlive);
		transform.Rotate(Vector3.up, m_rotateSpeed * Time.deltaTime);

	}
}
