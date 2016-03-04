using UnityEngine;
using System.Collections;

public class TimeScaleController : MonoBehaviour
{
	[Range(0, 10f)]
	public float timeScale = 1.0f;

	void Start ()
	{
		Time.timeScale = timeScale;
	}
}
