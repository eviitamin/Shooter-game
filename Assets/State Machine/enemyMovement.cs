using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement
{
    public static void MoveEnemy(Rigidbody2D rb, Vector3 destination, Vector3 enemyPosition, float speed){
        Rotate(rb, destination, enemyPosition);
        Move(rb, destination, enemyPosition, speed);
    }

    private static void Rotate(Rigidbody2D rb, Vector3 destination, Vector3 enemyPosition){
        var direction = (destination - enemyPosition).normalized;

        float rotation_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.SetRotation(rotation_z - 90);
    }

    private static void Move(Rigidbody2D rb, Vector3 destination, Vector3 enemyPosition, float speed){
        var direction = (destination - enemyPosition).normalized;
        rb.velocity = direction * speed * Time.deltaTime;
    }

}
