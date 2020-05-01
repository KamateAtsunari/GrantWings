using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[SerializeField] private GameObject explo;
	
	void OnCollisionEnter(Collision col) {
	
		GameObject.Instantiate(explo, col.contacts[0].point, Quaternion.identity);
	
		Destroy(gameObject);
	}
	
	
}
