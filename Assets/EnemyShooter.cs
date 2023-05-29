using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject eBullet;
    public Transform eBulletpos;
    private GameObject player;
    private float rtimer;
    public float eammo;
    public bool reload;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rtimer=5;
        eammo=12;
    }

    // Update is called once per frame
    void Update()
    {
       rtimer+=Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if(distance < 4.5){
             timer += Time.deltaTime;
            if (timer >1){
                 timer =0;
                 shoot();
                 
            }
        }
        
        
    }
    void shoot(){
        eammo-=1;
        
        if (rtimer>4){
    if(reload){
        eammo=12;
        reload=false;
    }
    Instantiate(eBullet, eBulletpos.position, Quaternion.identity);
    }
    if (eammo < 1){
        if (!reload){
        rtimer = 0;
        reload=true;}
    }
    }
}
