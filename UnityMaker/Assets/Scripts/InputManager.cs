using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
   public static bool JumpButtonPressed
    {
        get
        {
            return Input.GetKeyDown(KeyCode.UpArrow);
        }
    }
    public static bool AttackButtonPressed
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
    public static bool JumpButton
    {
        get
        {
            return Input.GetKey(KeyCode.UpArrow);
        }
    }
    public static bool AttackButton
    {
        get
        {
            return Input.GetKey(KeyCode.Space);
        }
    }
    public static float HorizontalAxis
    {
        get
        {
            return Input.GetAxis("Horizontal");
        }
    }
}
