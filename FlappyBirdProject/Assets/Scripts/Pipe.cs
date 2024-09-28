using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public static float globalSpeed = 1f;

    public void Move(float time)
    {
        transform.position += Vector3.left * globalSpeed * time;
    }
}
