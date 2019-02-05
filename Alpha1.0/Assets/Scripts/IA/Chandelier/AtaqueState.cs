using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueState : StateMachineBehaviour {

    //Un gameObject para hacer referencia a la máscara 
    GameObject mask;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Se reproduce animación de despertar. Este estado debe indicar que hasta que la animación no termine no se puede pasar al siguiente estado. 
        animator.SetBool("atacarJugador", false);

        //Encuentra el gameObject que posea el tag Mask creado previamente en el inspector de Unity
        mask = GameObject.FindGameObjectWithTag("BlackMask");
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("atacarJugador", false);

        //Si no hay máscara, vuelve verdadero el booleano.
        if (mask == null)
        {
            Debug.Log("mascara arrancada");
            animator.SetBool("mascaraArrancada", true);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Establece el bool en false, facilitando que pueda volver a ser true el booleano cuando vuelvan a darse las condiciones.
        animator.SetBool("atacarJugador", false);
    }
}
