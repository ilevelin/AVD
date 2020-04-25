using CreatorKitCodeInternal;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModdedTurretController : MonoBehaviour
{
    public GameObject bullet;
    public bool limitedTime;
    [Min(0)] public float timeAlive;
    [Min(0)] public float bulletSpeed;
    public Animator turretAnimator;
    public Animator[] gunsAnimator;
    public Transform[] gunsPosition;
    [Range(0.01f, 1f)] public float shootFrequency;
    private GameObject objective = null;
    [Min(0f)] public float detectionRadius = 15;

    void Start()
    {
        if(limitedTime) StartCoroutine(LimitedTime());
    }
    private void FixedUpdate()
    {
        if (objective != null && k) StartCoroutine(Fire());
        if (Input.GetKey(KeyCode.O)) {StopAllCoroutines(); StartCoroutine(Die());}
    }
    private void Update()
    {
        GameObject[] tmpEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        int closestIndex = -1;
        float closestDistance = 1000000;
        for (int i = 0; i < tmpEnemies.Length; i++)
        {
            if (tmpEnemies[i].GetComponents<SimpleEnemyController>().Length != 0)
            {
                float tmp = Vector3.SqrMagnitude(tmpEnemies[i].transform.position - transform.position);
                if ((tmp < (detectionRadius * detectionRadius)) && (tmp < closestDistance))
                {
                    closestIndex = i;
                    closestDistance = tmp;
                }
            }
        }

        if (closestIndex == -1)
        {
            turretAnimator.SetBool("EnemyFound", false);
            objective = null;
        }
        else
        {
            turretAnimator.SetBool("EnemyFound", true);
            objective = tmpEnemies[closestIndex];
        }

        if (objective != null)
        {
            Vector3 relativePosition = objective.transform.position - transform.position;
            float x, z;
            if(Math.Abs(relativePosition.x) > Math.Abs(relativePosition.z))
            {
                x = relativePosition.x / Math.Abs(relativePosition.x);
                z = relativePosition.z / Math.Abs(relativePosition.x);
            }
            else
            {
                x = relativePosition.x / Math.Abs(relativePosition.z);
                z = relativePosition.z / Math.Abs(relativePosition.z);
            }

            turretAnimator.SetFloat("EnemyRelativeX", x);
            turretAnimator.SetFloat("EnemyRelativeZ", z);
        }
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
