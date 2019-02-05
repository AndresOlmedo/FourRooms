using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrullaState : StateMachineBehaviour {

    //Llámamos a la malla de navegación
    UnityEngine.AI.NavMeshAgent agent;
    //Array que contiene los objetos denominados "Goal". 
    public GameObject[] goal;
    //Creamos un int que se contendrán en la matriz goal
    int currentPoint = 0;
    //Bool para comprobar si se ha iniciado el conteo de waypoints
    bool inicializado = false;

    //Un gameObject y un vector para hacer referencia al jugador y guardar su posicion
    GameObject player;
    public Vector3 playerPosition;

    //Un gameObject para hacer referencia a la máscara 
    GameObject mask;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Llamamos a la malla de navegación
        agent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
        //Encuentra el gameObject que posea el tag Player creado previamente en el inspector de Unity
        player = GameObject.FindGameObjectWithTag("Player");
        //Encuentra todos los gameObjects que posean en tag Goal creado previamente en el inspector de Unity
        goal = GameObject.FindGameObjectsWithTag("Silla_Goal");
        //El destino del NavMeshAgent debe ser el primer valor de la matriz 
        agent.destination = goal[0].transform.position;
        //Encuentra el gameObject que posea el tag Mask creado previamente en el inspector de Unity
        mask = GameObject.FindGameObjectWithTag("BlackMask");

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Relacionar el Vector3 a la posicion del jugador en el momento del cambio de estado para que guarde esta posición.
        playerPosition = player.transform.position;
        //Si la distancia con el jugador es menor de 10, continúa.
        if (Vector3.Distance(animator.transform.position, playerPosition) < 10.0f)
        {
            //Hacer que un inicio vaya a la posición indicada, la del jugador en el momento en que se entra en este estado, y vuelve verdadero el booleano.
            agent.destination = playerPosition;
            animator.SetBool("jugadorDetectado", true);
        }
        else
        {
            //Debug.Log("Did not Hit");
        }

        //En cada Update, realiza lo que se ordena en moveToNextPoint
        MoveToNextPoint();

        if (!inicializado)
        {
            //Establece en base, el float adquiere el valor 0 y el bool se vuelve verdadero
            base.OnStateEnter(animator, stateInfo, layerIndex);
            currentPoint = 0;
            inicializado = true;
        }

        //Si no hay máscara, vuelve verdadero el booleano.
        if (mask == null)
        {
            Debug.Log("mascara arrancada");
            animator.SetBool("mascaraArrancada", true);
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
