using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponHandling : MonoBehaviour
{
    string[] firepoints = {"FirePointPistol","FirePointSniper","FirePointRocket","FirePointSMG"};
    private int selectedWeapon = 0;
    // Start is called before the first frame update

    public int damage,magSize;
    public float timeBetweenShots,reloadTime;
    public TMP_Text ammoDisplay;

    Animator currWeaponAnimator;
    int bulletsLeft;

    bool reloading,readyToShoot;

    void Start()
    {
        reloading = false;
        readyToShoot = true;
        SelectWeapon();
        SetWeapon(selectedWeapon);
        currWeaponAnimator = transform.GetChild(selectedWeapon).gameObject.GetComponent<Animator>();
    }

    public float Shoot(GameObject weapon) {
        if(bulletsLeft > 0 && !reloading && readyToShoot) {
            readyToShoot = false;
            bulletsLeft--;
            ammoDisplay.text =bulletsLeft.ToString() + " / " + magSize.ToString();
            if (selectedWeapon == 2) {
                transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            else {
                currWeaponAnimator.Play("Shoot");
            }
            Invoke("ResetShot",timeBetweenShots);
            return(weapon.GetComponent<ShootProjectile>().shoot());
        }
        return(0f);
    }
    private void ResetShot() {
        readyToShoot = true;
    }

    public void Reload() {
        if(readyToShoot) {
            reloading = true;
            currWeaponAnimator.Play("Reload");
            Invoke("ReloadFinished",reloadTime);
        }
    }

    private void ReloadFinished() {
        bulletsLeft = magSize;
        reloading = false;
        ammoDisplay.text =bulletsLeft.ToString() + " / " + magSize.ToString();
        if (selectedWeapon == 2) {
           transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public string swapWeapon() 
    {
        if(!reloading) {
            selectedWeapon = (selectedWeapon +1) %4;
            currWeaponAnimator = transform.GetChild(selectedWeapon).gameObject.GetComponent<Animator>();
            SetWeapon(selectedWeapon);
            SelectWeapon();
        }
        return(firepoints[selectedWeapon]);
    }

    private void SelectWeapon() 
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    private void SetWeapon(int type) {
        if(type == 0) {
            magSize = 12;
            timeBetweenShots = 0.2f;
            reloadTime = 1;
            bulletsLeft = 12;
        }
        else if (type == 1)
        {
            magSize = 4;
            timeBetweenShots = 1f;
            reloadTime = 3;
            bulletsLeft = 4;

        }
        else if (type == 2)
        {
            magSize = 1;
            timeBetweenShots = 1f;
            reloadTime = 3;
            bulletsLeft = 1;

        }
         else if (type == 3)
        {
            magSize = 30;
            timeBetweenShots = 0.1f;
            reloadTime = 1.2f;
            bulletsLeft = 30;

        }
        ammoDisplay.text =bulletsLeft.ToString() + " / " + magSize.ToString();
    }
}
