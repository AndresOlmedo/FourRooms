using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespertarState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Se reproduce animación de despertar. Este estado debe indicar que hasta que la animación no termine no se puede pasar al siguiente estado. 
        animator.SetBool("animacionDespertarRealizada", true);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
