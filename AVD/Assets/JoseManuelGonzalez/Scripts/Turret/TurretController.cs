using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    /*
      scripts resueltos:
         https://github.com/amunyoz/AVD/blob/Turret/AVD/Assets/TriggerInputP.cs
         https://github.com/amunyoz/AVD/blob/Turret/AVD/Assets/TurretActivator.cs
         https://github.com/amunyoz/AVD/blob/Turret/AVD/Assets/FireBullets3d.cs
     */

    public GameObject bullet;
    public bool limitedTime;
    [Min(0)] public float timeAlive;
    public Animator turretAnimator;
    public Animator[] gunsAnimator;
    public Transform[] gunsPosition;
    [Range(0.1f, 2.5f)] public float shootFrequency;

    void Start()
    {
        if(limitedTime) StartCoroutine(LimitedTime());
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && k) StartCoroutine(Fire());
    }

    IEnumerator LimitedTime()
    {
        yield return new WaitForSeconds(timeAlive);
        turretAnimator.SetTrigger("Destroy");
        yield return null;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private int i = 0;
    private bool k = true;
    IEnumerator Fire()
    {
        k = false;
        gunsAnimator[i].SetTrigger("Shoot");
        Instantiate(bullet, gunsPosition[i].position, gunsPosition[i].rotation); //PIVOT =/= CENTER; FIX

        i = ++i % gunsPosition.Length;
        yield return new WaitForSeconds(shootFrequency);
        k = true;
    }
}
