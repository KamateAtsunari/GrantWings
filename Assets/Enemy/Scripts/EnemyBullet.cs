using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	[SerializeField]
	private GameObject explo = null;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag != "Enemy")
		{
			GameObject.Instantiate(explo, collision.contacts[0].point, Quaternion.identity);

			Destroy(gameObject);
		}
	}
}
