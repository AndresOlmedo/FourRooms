using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroll : MonoBehaviour {
    //Creamos una array de nombre goal
    public Transform[] goal;
    //Creamos un int que se contendrán en la matriz goal
    private int currentPoint = 0;
    //Llámamos al NavMeshAgent del gameObject al que se le va a aplicar el script
    NavMeshAgent agent;

    void Start()
    {
        //Hacemos referencia al NavMeshAgent para que use dicha propiedad 
        agent = GetComponent<NavMeshAgent>();
        //El destino del NavMeshAgent debe ser el primer valor de la matriz (indicado en Unity)
        agent.destination = goal[0].position;
    }
    void Update()
    {
        //En cada Update, realiza lo que se ordena en moveToNextPoint
        moveToNextPoint();

    }

    void moveToNextPoint()
    {
        //Si la distancia del agente frente al objetivo es menor del valor escrito, cotinúa
        if (agent.remainingDistance < 0.5f)

        {
            //El destino del agente debe ser la posición del objeto que represente al número equivalente al resto surgido de la división
            //del int, comenzando por 0, entre la longitud de la matriz 
            agent.destination = goal[++currentPoint % goal.Length].position;
        }


    }

}

