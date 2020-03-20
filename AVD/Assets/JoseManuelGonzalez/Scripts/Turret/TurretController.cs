using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject bullet;
    public bool limitedTime;
    [Min(0)] public float timeAlive;
    [Min(0)] public float bulletSpeed;
    public Animator turretAnimator;
    public Animator[] gunsAnimator;
    public Transform[] gunsPosition;
    [Range(0.01f, 1f)] public float shootFrequency;

    void Start()
    {
        if(limitedTime) StartCoroutine(LimitedTime());
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && k) StartCoroutine(Fire());
        if (Input.GetKey(KeyCode.O)) {StopAllCoroutines(); StartCoroutine(Die());}
    }
    private int i = 0;
    private bool k = true;
    IEnumerator Fire()
    {
        k = false;
        gunsAnimator[i].SetTrigger("Shoot");
        GameObject clone = Instantiate(bullet, gunsPosition[i].position, gunsPosition[i].rotation);
        clone.GetComponent<Rigidbody>().AddRelativeForce(0.0f, 5f, bulletSpeed);

        i = ++i % gunsPosition.Length;
        yield return new WaitForSeconds(shootFrequency);
        k = true;
    }

    IEnumerator LimitedTime()
    {
        yield return new WaitForSeconds(timeAlive);
        k = false;
        turretAnimator.SetTrigger("Destroy");
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator Die(){
        k = false;
        turretAnimator.SetTrigger("Destroy");
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        yield return null;
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
