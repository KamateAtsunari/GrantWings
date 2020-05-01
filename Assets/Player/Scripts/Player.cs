using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject explo = null;
    [SerializeField]
    private SimpleHealthBar healthBar = null;


    private float maxHp = 100;
    private float hp = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheakDeath();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            hp = 0;
        }
        if(collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            hp -= 20;
            healthBar.UpdateBar(hp, maxHp);
            Debug.Log(hp);
        }
    }
    private void CheakDeath()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            GameObject.Instantiate(explo, this.transform.position, Quaternion.identity);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
