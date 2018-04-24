using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{

    bool bAxisInUse = false;

    // The input for horizontal movement
    public float Horizontal
    {
        get
        {
            return Input.GetAxis("Horizontal");
        }
    }

    // The input for vertical movement
    public float Vertical
    {
        get
        {
            return Input.GetAxis("Vertical");
        }
    }

    public float Boost
    {
        get
        {
            return Input.GetAxis("Boost");
        }
    }

    public bool AddForce
    {
        get
        {
            if (Input.GetAxisRaw("AddForce") != 0)
            {
                if (bAxisInUse == false)
                {
                    bAxisInUse = true;
                    return true;
                }
            }
            if (Input.GetAxisRaw("AddForce") == 0)
            {
                bAxisInUse = false;
            }
            return false;
        }
    }

    // The input for horizontal movement
    public float RightHorizontal
    {
        get
        {
            return Input.GetAxis("RightHorizontal");
        }
    }

    // The input for vertical movement
    public float RightVertical
    {
        get
        {
            return Input.GetAxis("RightVertical");
        }
    }

}
