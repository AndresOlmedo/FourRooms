using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject door;
    public Vector3 doorPosition;

    void Start()
    {
        doorPosition = door.transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, doorPosition) < 4.0f)
        {
            //Y se pulsa el botón F.
            if (Input.GetKeyDown(KeyCode.F))
            {
                //
                Debug.Log("Sale de la habitacion");
                SceneManager.LoadScene(0);
            }
        }
    }
}
