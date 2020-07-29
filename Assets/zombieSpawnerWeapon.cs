using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawnerWeapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] GameObject ZombiePrefab;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] float TimeBetweenShots = 0.5f;
    bool canShoot = true;


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        PlayMuzzleFlash();
        ProcessRaycast();
        yield return new WaitForSeconds(TimeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit))
        {
            CreateZombieOnHitImpact(hit);
        }

    }

    private void CreateZombieOnHitImpact(RaycastHit hit)
    {
        Debug.Log("Hit: " + hit.transform.name);
        GameObject impact = Instantiate(ZombiePrefab, hit.point, Quaternion.LookRotation(hit.normal));
    }
}
