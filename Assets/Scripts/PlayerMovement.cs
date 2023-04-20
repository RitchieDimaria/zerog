using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform orientation;
    private GameObject weapon;
    private WeaponHandling wh;
    public GameObject enemy;

    public bool spawning = true;
    int i = 0;

    Vector3 moveDirection;
    Rigidbody rb;
    GameObject SpawnPoints;


    private string currentGun = "FirePointPistol";
    Quaternion halfRotation = Quaternion.Euler(0, 180, 0);


    // Start is called before the first frame update
    void Start()
    {
        SpawnPoints =GameObject.Find("SpawnPoints");
        rb = GetComponent<Rigidbody>();
        weapon = GameObject.Find(currentGun);
        wh = GameObject.Find("WeaponHolster").GetComponent<WeaponHandling>();

        if(spawning) {
            StartCoroutine(Spawnbots());
        }
        //rb.freezeRotation = true; //Stop player from falling over
    }

    private void MyInput()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            float vel =wh.Shoot(weapon); //shoot gun
            MovePlayer(vel); // move player
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentGun = wh.swapWeapon();
            weapon = GameObject.Find(currentGun);
        }
        if (Input.GetKeyDown(KeyCode.R))
        { 
            wh.Reload();

        }
        if (Input.GetKey(KeyCode.Q))
        { 
            rb.drag = 4; //If Q is pressed apply airbreaks
        }
        else
        {
            rb.drag = 0.3f;
        }
    }

    public void MovePlayer(float launchVelocity)
    {
        //calculate movement direction
        moveDirection = weapon.GetComponent<Transform>().forward * -1;
        rb.AddForce(moveDirection.normalized*launchVelocity,ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private IEnumerator Spawnbots()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(5); 
            Instantiate(enemy,SpawnPoints.transform.GetChild(i).gameObject.transform); 
            i = (i +1) %4;
        }
    }
}