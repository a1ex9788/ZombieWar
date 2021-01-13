using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick movementJoystick;
    public FixedJoystick aimingJoystick;

    public GameObject weapon;
    public GameObject shotPoint;

    public float movementFriction;

    //Aux
    public bool toRight = true;
    public float weaponRotation = 0;
    private int rotationOffset;


    void Update()
    {
        MovementManagement();
        AimingManagement();
    }


    void MovementManagement() {
        float x = movementJoystick.Horizontal;
        float y = movementJoystick.Vertical;

        //Movement animation
        if (x == 0 && y == 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Move", false);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Move", true);
        }

        //Flip player
        bool prevToRight = toRight;
        if (x > 0) { toRight = true; }
        else if (x < 0) { toRight = false; }
        FlipSpritesManagement();

        if (prevToRight != toRight) //Change of way
        {
            weapon.transform.rotation = Quaternion.Euler(0, 0, -weaponRotation);
            weaponRotation = -weaponRotation;
        }

        //Move
        gameObject.transform.position += new Vector3(x, y) / movementFriction;
    }

    void AimingManagement() {
        float x = aimingJoystick.Horizontal;
        float y = aimingJoystick.Vertical;

        if (x == 0 && y == 0) {} //Nothing
        else
        {
            float rotation = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

            //Flip weapon
            if (rotation < 90 && rotation > -90) { toRight = true; }
            else  { toRight = false; }
            FlipSpritesManagement();

            //Hide or show weapon
            if (rotation > 0 && rotation < 180) { weapon.GetComponent<SpriteRenderer>().sortingOrder = 3; }
            else { weapon.GetComponent<SpriteRenderer>().sortingOrder = 10; }

            //Rote
            weaponRotation = rotation + rotationOffset;
            weapon.transform.rotation = Quaternion.Euler(0f, 0f, weaponRotation);
        }
    }

    //Aux
    void FlipSpritesManagement() {
        gameObject.GetComponent<SpriteRenderer>().flipX = !toRight;
        weapon.GetComponent<SpriteRenderer>().flipX = !toRight;

        if (toRight) { rotationOffset = 0; }
        else { rotationOffset = 180; }

        //Change the position of the shotPoint
        if (toRight)
        {
            shotPoint.transform.localPosition = new Vector3(0.27f, shotPoint.transform.localPosition.y);
        }
        else {
            shotPoint.transform.localPosition = new Vector3(-0.27f, shotPoint.transform.localPosition.y);
        }
    }
}
