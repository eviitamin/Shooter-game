using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnife : MonoBehaviour
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
        rtimer=1;
        eammo=7;
    }

    // Update is called once per frame
    void Update()
    {
       rtimer+=Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if(distance < 2){
             timer += Time.deltaTime;
            if (timer >1){
                 timer =0;
                 shoot();
                 
            }
        }
        
        
    }
    void shoot(){
        eammo-=1;
        
        if (rtimer>1){
    if(reload){
        eammo=7;
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
