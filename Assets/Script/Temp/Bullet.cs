using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IWeapon
{
	public void Shoot(GameObject obj)
	{
		Vector3 initialPosition = new Vector3(transform.position.x, transform.position.y, 0);
		GameObject bullet = Instantiate(obj);
		bullet.transform.position = initialPosition;
	}
}
