using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public static float vida=100;
    private void Update()
    {
        if (vida <= 0)
        {
            print("Morreu");
        }
    }
}

