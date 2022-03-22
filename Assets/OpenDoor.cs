using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject pos;
    public GameObject pos2;
    public int velo = 20;
   
   
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pos.transform.position = Vector3.LerpUnclamped(pos.transform.position, pos2.transform.position, Time.deltaTime * 10f*velo);
        }

    }
}
