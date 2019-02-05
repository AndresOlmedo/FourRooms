using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskCandelabro : MonoBehaviour
{
    //Para que se detecte a la máscara se requiere un GameObject y un vector que se vaya a relacionar con la máscara.
    public GameObject mask;
    public Vector3 maskPosition;

    //booleano para que, cuando la máscara desaparezca, deje de buscar la posición.
    bool buscaMaskPosition = true;

    // Update is called once per frame
    void Update()
    {
        if (buscaMaskPosition == true)
        {
            //Relacionamos el vector con la posición de la máscara. 
            maskPosition = mask.transform.position;
        }

        //Si la distancia entre el jugador y la máscara es menor de lo indicado
        if (Vector3.Distance(transform.position, maskPosition) < 4.0f)
        {
            //Y se pulsa el botón F.
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Se destruye la máscara. Se elimina el Vector3 para que la consola no intente buscar una posición que ya no existe. 
                Debug.Log("Botón pulsado");
                Destroy(mask);
                buscaMaskPosition = false;
            }
        }

    }
}
