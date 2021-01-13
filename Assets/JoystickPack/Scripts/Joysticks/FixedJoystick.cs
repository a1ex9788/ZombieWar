using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    public Shooting shooting;

    private void Awake()
    {
        shooting = FindObjectOfType<Shooting>();
    }

    public override void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);

        if (gameObject.name == "AimingJoystick") { shooting.Shoot(); }
    }
}