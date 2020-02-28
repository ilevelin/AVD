using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectibleType { Cherry = 0, Gem = 1 }
public class Collectible : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CollectibleType type;

    public void Start()
    {
        animator.SetInteger("Type", (int) type);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Collected", true);
    }
}
