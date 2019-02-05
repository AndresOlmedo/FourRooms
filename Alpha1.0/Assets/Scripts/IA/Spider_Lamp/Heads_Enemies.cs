using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Heads_Enemies : MonoBehaviour
{
    //public NavMeshAgent Harlute;
    //public NavMeshAgent Marlute;
    //public NavMeshAgent Sundel;
    //public NavMeshAgent Metatron;

    public NavMeshAgent[] Cabezas;

    public Transform [] Harlutewp;
    public Transform [] Marlutewp;
    public Transform [] Sundelwp;
    public Transform [] Metatronwp;


    // Use this for initialization
    void Start ()
    {
        GetComponent<NavMeshAgent>(); 
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
