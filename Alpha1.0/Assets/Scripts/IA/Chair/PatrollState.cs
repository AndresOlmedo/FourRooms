using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollState : StateMachineBehaviour {

    //Llámamos a la malla de navegación
    UnityEngine.AI.NavMeshAgent agent;
    //Necesito: int que cuente los puntos del array, un array. 
    public GameObject[] goal;
    //Creamos un int que se contendrán en la matriz goal
    int currentPoint = 0;
    //Bool para comprobar si se ha iniciado el conteo de waypoints
    bool inicializado = false;

    //Rayo del raycast
    RaycastHit hit;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Llamamos a la malla de navegación
        agent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
        //Encuentra todos los gameObjects que posean en tag Goal creado previamente en el inspector de Unity
        goal = GameObject.FindGameObjectsWithTag("Goal");
        //El destino del NavMeshAgent debe ser el primer valor de la matriz 
        agent.destination = goal[0].transform.position;
        //El color de este agente en este estado es azul
        agent.GetComponent<Renderer>().material.color = Color.blue;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //En cada Update, realiza lo que se ordena en moveToNextPoint
        MoveToNextPoint();
        //Que el rayo se vea en la escena por defecto de color azul.
        Debug.DrawRay(animator.transform.position, animator.transform.forward * 10, Color.blue);
        //Función para el raycast. Si el rayo colisiona con el jugador, color rojo.
        if (Physics.Raycast(animator.transform.position, animator.transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            Debug.DrawRay(animator.transform.position, animator.transform.forward * 2, Color.red);
            //Debug.Log("Did hit");
            //Establece en verdadero este booleano, lo que conlleva que pase al estado Deteccion
            animator.SetBool("JugadorDetectado", true);
        }
        else
        {
            //Debug.Log("Did not Hit");
        }

        if (!inicializado)
        {
            //Establece en base, el float adquiere el valor 0 y el bool se vuelve verdadero
            base.OnStateEnter(animator, stateInfo, layerIndex);
            currentPoint = 0;
            inicializado = true;
        }


    }
    void MoveToNextPoint()
    {
        //Si la distancia del agente frente al objetivo es menor del valor escrito, continúa
        if (agent.remainingDistance < 0.5f)
        {
            //El destino del agente debe ser la posición del objeto que represente al número equivalente al resto surgido de la división
            //del int, comenzando por 0, entre la longitud de la matriz 
            agent.destination = goal[++currentPoint % goal.Length].transform.position;
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
