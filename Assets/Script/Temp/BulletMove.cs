using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour
{
	float Speed = 10.0f;
	float timer;

    private void Awake()
    {
		timer = Time.time + 1.0f;
	}

    void Update()
	{
		transform.Translate(Vector3.up * Speed * Time.deltaTime);

		if (Time.time > timer)
		{
			Destroy(gameObject);
		}
	}
}
