using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TreasureChest : MonoBehaviour
{
    public LayerMask mask;
    private bool closed = true;



    private void OnTriggerEnter(Collider collision)
    {
        if (closed && (mask == (mask | (1 << collision.gameObject.layer))))
        {
            gameObject.GetComponent<PlayableDirector>().Play();
            StartCoroutine(LogicUpdate());
        }

    }

    IEnumerator LogicUpdate()
    {
        closed = false;
        yield return new WaitForSeconds(7);
        GameObject.FindGameObjectWithTag("ModdedManager").GetComponent<ModController>().AddCharge();
    }

}
