using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject bullet;
    public float launchVelocity = 750f;
    // Start is called before the first frame update

    public float shoot(){
        GameObject projectile = Instantiate(bullet,transform.position,transform.rotation);
        //Debug.Log("Fired a"+ bullet.name);
        projectile.transform.Rotate (90f, 0f, 0f);
        if (bullet.name == "Rocket") {
            projectile.transform.Rotate (0f, 0f, 90f);
        }

        Destroy(projectile,10);
        projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0,launchVelocity));
        return launchVelocity;
    }
}
