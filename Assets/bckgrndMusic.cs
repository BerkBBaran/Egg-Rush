using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bckgrndMusic : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
