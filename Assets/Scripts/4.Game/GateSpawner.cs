using UnityEngine;
using System.Collections;

public class GateSpawner : MonoBehaviour
{
	[SerializeField] Transform m_gate;
	public float interval = 5.0f;

	void Start ()
	{
		StartCoroutine(Spawn());
	}
	
	IEnumerator Spawn ()
	{
		while(true)
		{
			Transform gate = Instantiate(m_gate);
			gate.SetParent(transform);
			gate.localPosition = Vector3.zero;
			yield return new WaitForSeconds(interval);
		}
	}
}
