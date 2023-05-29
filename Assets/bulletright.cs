using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletright : MonoBehaviour
{
    private float timer;
    private void OnCollisionEnter2D(Collision2D collision){
         Destroy(gameObject);
        if(collision.collider.gameObject.tag == "Enemy"){
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }
    }
    void Start(){

    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >.05){
            Destroy(gameObject);
        }
    }
}
