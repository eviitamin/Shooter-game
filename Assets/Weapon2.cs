using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
public GameObject bulletPrefab;
public Transform firePoint;
public float fireForce = 20f;
private float timer;
private float rtimer;
public float pammo;
public bool reload; //0 has ammo, 1 has reloaded

void Start(){
    pammo = 3;
    rtimer=1;
}

void Update(){
timer += Time.deltaTime;
rtimer += Time.deltaTime;

}



public void Fire(){
    Debug.Log(rtimer);
    if (rtimer>1){
    if(reload){
        pammo=5;
        reload=false;
    }
    if (timer>.3){
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    Debug.Log(pammo);
    bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    timer = 0;
    pammo-=1;}}
    if (pammo < 1){
        if (!reload){
        rtimer = 0;
        reload=true;}
    }
}

}
