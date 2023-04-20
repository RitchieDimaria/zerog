using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController  : MonoBehaviour
{

    public GameObject FloatingTextPrefab;
    private Transform target;
    private float speed = 3f;
    private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>(); //Find player
        
    }

    // Update is called once per frame
    void Update()
    { //Constantly face and move toward the player
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
        
    }

    void ShowFloatingText(int damage) { //Show the damage the player does on collision
        Vector3 rot = transform.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y + 180, rot.z);
        var text = Instantiate(FloatingTextPrefab,transform.position,Quaternion.Euler(rot));
        text.GetComponent<TextMesh>().text = damage.ToString();
    }

    void OnCollisionEnter(Collision col) {
        //Debug.Log(col.gameObject.name);
        // Take damage
        if(col.gameObject.name == "BulletPistol(Clone)")
        {
            health-=20;
            ShowFloatingText(20);
        }
        else if(col.gameObject.name == "BulletSMG(Clone)")
        {
            health-=10;
            ShowFloatingText(10);
        }
        else if(col.gameObject.name == "BulletSniper(Clone)")
        {
            health-=100;
            ShowFloatingText(100);
        }
        else if(col.gameObject.name == "Explosion(Clone)")
        {
            health-=45;
            ShowFloatingText(45);
        }
        else if(col.gameObject.name == "Rocket(Clone)")
        {
            health-=45;
            ShowFloatingText(55);
        }

        if(health <= 0)
        {
            Destroy(col.gameObject,1);
            Destroy(this.gameObject);
        }
    }
}
