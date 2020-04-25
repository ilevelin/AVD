using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteButton : MonoBehaviour
{

    public string trigger = "";

    private SpriteRenderer sprite;
    public Color idleColor, hoverColor, clickColor;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = idleColor;
    }

    private void OnMouseEnter()
    {
        sprite.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sprite.color = idleColor;
    }

    private void OnMouseDown()
    {
        sprite.color = clickColor;
        if (trigger.Length != 0)
            GameObject.FindGameObjectWithTag("CameraObjective").GetComponent<Animator>().SetTrigger(trigger);
    }

    private void OnMouseUp()
    {
        sprite.color = hoverColor;
    }
}