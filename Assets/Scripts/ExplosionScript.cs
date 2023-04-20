using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public GameObject explosionEX;
    void OnCollisionEnter(Collision col) {
        Instantiate(explosionEX,transform.position,transform.rotation);
        Destroy(this.gameObject);
    }
}
