using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    public NavMeshAgent inimigo;
    Vector3 pos;
    Quaternion rot;
    public int velo;
    public GameObject player;
    public GameObject[] aiPoints;

    void Start()
    {
        inimigo = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        
    }
    public void GetAiPoints()
    {
        pos = inimigo.transform.position;
        rot = inimigo.transform.rotation;
        for (int i = 0; i < aiPoints.Length; i++)
        {
            pos = aiPoints[i].transform.position;
            
        }
    }
}
