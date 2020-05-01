using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explo;
    [SerializeField] private UIManager uiManager = null;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform point = null;
    [SerializeField] private int hp = 50;

    private float time;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(hp <= 0)
        {
            uiManager.AddScore();
            GameObject.Instantiate(explo, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        
    }
    // 物体がトリガーに接触している間、常に呼ばれる
    private void OnTriggerStay(Collider collision){
        if (collision.gameObject.tag == "Player"){
            this.transform.LookAt(collision.transform);
            time += Time.deltaTime;
            if (time >= 1.5f)
            {   
                shot(collision.gameObject);
                time = 0;
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= 20;
            //Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Missile")
        {
            hp -= 50;
            //Destroy(this.gameObject);
        }
    }
    public void shot(GameObject target){
        //Debug.LogFormat("秒経過");
        if (bullet != null)
        {
            GameObject shotObj = (GameObject)Instantiate(bullet, point.position, Quaternion.identity);
            shotObj.transform.LookAt(target.transform);
            shotObj.GetComponent<Rigidbody>().AddForce((shotObj.transform.forward) * 10000f);
            
            //Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            //bulletRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            //bulletRigidbody.AddForce(transform.forward * 9000f);

        }

    }
}
