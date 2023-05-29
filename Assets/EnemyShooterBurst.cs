using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterBurst : MonoBehaviour
{
   public GameObject eBullet;
    public Transform eBulletpos;
    private GameObject player;
    private float rtimer;
    public float eammo;
    public bool reload;
    private float timer;
    private float step = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rtimer=6;
        eammo=5;
        
    }

    // Update is called once per frame
    void Update()
    {
       rtimer+=Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if(distance < 8
        
        ){
             timer += Time.deltaTime;
            if (timer >2){
                 timer =0;
                 shoot();
                 
            }
        }
        
        
    }

    IEnumerator burst(){
        yield return new WaitForSeconds(step);
        Instantiate(eBullet, eBulletpos.position, Quaternion.identity);
        yield return new WaitForSeconds(step);
        Instantiate(eBullet, eBulletpos.position, Quaternion.identity);
        yield return new WaitForSeconds(step);
        Instantiate(eBullet, eBulletpos.position, Quaternion.identity);

    }

    void shoot(){
        eammo-=1;
        
        if (rtimer>5.4){
    if(reload){
        eammo=5;
        reload=false;
    }

    StartCoroutine(burst());

    }
    if (eammo < 1){
        if (!reload){
        rtimer = 0;
        reload=true;}
    }
    }
}

