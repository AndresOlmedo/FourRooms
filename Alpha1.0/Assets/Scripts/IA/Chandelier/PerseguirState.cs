using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguirState : StateMachineBehaviour
{

    //Un gameObject y un vector para hacer referencia al jugador y guardar su posicion
    GameObject player;
    Vector3 playerPosition;

    //Llámamos al NavMeshAgent del gameObject al que se le va a aplicar el script
    UnityEngine.AI.NavMeshAgent agent;

    //float para que cuando se cumpla cierto tiempo, vuelva al estado de patrulla.
    public float time = 0.0f;

    //Un gameObject para hacer referencia a la máscara 
    GameObject mask;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Llamar al componente de NavMeshAgent del agente.
        agent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
        //Encuentra el gameObject que posea el tag Player creado previamente en el inspector de Unity
        player = GameObject.FindGameObjectWithTag("Player");
        //Relacionar el Vector3 a la posicion del jugador en el momento del cambio de estado para que guarde esta posición.
        playerPosition = player.transform.position;

        //Encuentra el gameObject que posea el tag Mask creado previamente en el inspector de Unity
        mask = GameObject.FindGameObjectWithTag("BlackMask");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Que haga una cuenta del tiempo nada más iniciar el estado.
        time += Time.deltaTime;

        //Una vez esté a una posición menor de 1.0f del punto, .
        if (Vector3.Distance(animator.transform.position, playerPosition) < 1.0f)
        {
            //Hacer que un inicio vaya a la posición indicada, la del jugador en el momento en que se entra en este estado y vuelva verdadero el booleano.
            agent.destination = playerPosition;
            animator.SetBool("atacarJugador", true);
        }

        //Una vez esté a una posición mayor de 10.0f del punto.
        if (Vector3.Distance(animator.transform.position, playerPosition) > 10.0f)
        {
            //Establece además la variable JugadorDetectado a falso, lo que le hace volver al estado Patrulla.
            //Debug.Log("Did not Hit");
            animator.SetBool("jugadorDetectado", false);
        }

       //Si la persecución dura más de 5 segundos, el candelabro desistirá y volverá a patrullar. 
        if (time >= 5)
        {
            Debug.Log("El tiempo es 5");
            animator.SetBool("jugadorDetectado", false);
        }

        //Si no hay máscara, vuelve verdadero el booleano.
        if (mask == null)
        {
            Debug.Log("mascara arrancada");
            animator.SetBool("mascaraArrancada", true);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Establece el bool ya he esperado en false, facilitando que pueda volver a ser true el booleano cuando vuelvan a darse las condiciones.
        animator.SetBool("jugadorDetectado", false);
    }
}
