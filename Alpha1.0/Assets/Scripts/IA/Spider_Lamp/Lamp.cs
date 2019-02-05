using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lamp : MonoBehaviour
{
    GameObject Player;
    public int Lamplifes = 4;       //VIDAS DE LA LÁMPARA
    public float distanciaMuro;
    public float distanciaEmpujon; 

    public bool HarluteMask = false;
    private GameObject Harlute;
    
    public bool MarluteMask = false;
    private GameObject Marlute;

    public bool SundelMask = false;
    private GameObject Sundel;

    public bool MetatronMask = false;
    private GameObject Metatron;

    //public Animator HeadsAnimator;
    //public Animator LampAnimator;

    public AnimationClip IdleLampara;           //TODAS LAS ANIMACIONES QUE VAN A SER DE LA LÁMPARA
    private Animation IL;
    public AnimationClip DamagedLampara;
    private Animation DL; 
    public AnimationClip DeathLampara;
    private Animation DthL; 

    public AnimationClip HeadIdle;              // LAS ANIMACIONES DE LOS "MUROS"
    private Animation HI; 
    public AnimationClip HeadAttack;
    private Animation HA;
    public AnimationClip HeadDamaged;
    private Animation HD;
    public AnimationClip HeadDeath;
    private Animation HDth;



    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");        //DECLARACIÓN DE VARIABLES

        Harlute = GameObject.FindGameObjectWithTag("Harlute");
        Harlute.GetComponent<Collider>().enabled = true;

        Marlute = GameObject.FindGameObjectWithTag("Marlute");
        Marlute.GetComponent<Collider>().enabled = true;

        Sundel = GameObject.FindGameObjectWithTag("Sundel");
        Sundel.GetComponent<Collider>().enabled = true;

        Metatron = GameObject.FindGameObjectWithTag("Metatron");
        Metatron.GetComponent<Collider>().enabled = true;

   
        IL = GetComponent<Animation>();     //TODAS LAS DECLARACIONES ESTAN EN EL MISMO ORDEN QUE LAS VARIABLES QUE SE DAN ARRIBA
        DthL = GetComponent<Animation>();
        DL = GetComponent<Animation>();

        HI = GetComponent<Animation>();
        HA = GetComponent<Animation>();
        HD = GetComponent<Animation>();
        HDth = GetComponent<Animation>();

    }

    private void Start()
    {
        //LampAnimator.Play("Iddle");
        //HeadsAnimator.Play("Iddle");

        IL.Play(IdleLampara.name);
        HI.Play(HeadIdle.name); 

    }

    void Update ()
    {
        if (HarluteMask == true && Vector3.Distance(Harlute.transform.position, transform.position) < distanciaMuro)    // SEGUN LA DISTANCIA Y SI TIENE LA MASCARA CORRECTA EL ENEMIGO EMPIEZA A MORIR.
        {
            //Destroy(Harlute);
            Debug.Log("Harlute");
            Harlute.GetComponent<Collider>().enabled = false;               //EL COLLIDER DEL MURO SE DESACTIVA Y SE DAN LAS ANIMACIONES PERTINENTES

            //LampAnimator.Play("Damaged");
            //HeadsAnimator.Play("Death");
            Lamplifes--;
            DL.Play(DamagedLampara.name);
            HD.Play(HeadDamaged.name);

        }
        if (MarluteMask == true && Vector3.Distance(Marlute.transform.position, transform.position) < distanciaMuro)
        {
            //Destroy(Marlute);
            Debug.Log("Marlute");
            Marlute.GetComponent<Collider>().enabled = false;

            //LampAnimator.Play("Damaged");
            //HeadsAnimator.Play("Death");
            Lamplifes--;
            DL.Play(DamagedLampara.name);
            HD.Play(HeadDamaged.name);

        }
        if (SundelMask == true && Vector3.Distance(Sundel.transform.position, transform.position) < distanciaMuro)
        {
            //Destroy(Sundel);
            Debug.Log("Sundel");
            Sundel.GetComponent<Collider>().enabled = false;

            //LampAnimator.Play("Damaged");
            //HeadsAnimator.Play("Death");
            Lamplifes--;
            DL.Play(DamagedLampara.name);
            HD.Play(HeadDamaged.name);

        }
        if (MetatronMask == true && Vector3.Distance(Metatron.transform.position, transform.position) < distanciaMuro)
        {
            //Destroy(Metatron);
            Debug.Log("Metatron");
            Metatron.GetComponent<Collider>().enabled = false;

            //LampAnimator.Play("Damaged");
            //HeadsAnimator.Play("Death");
            Lamplifes--;
            //DL.Play(DamagedLampara.name);
            HD.Play(HeadDamaged.name);

        }


        if (Lamplifes == 0)
        {
            //LampAnimator.Play("Death"); 
            DthL.Play(DeathLampara.name);       //CUANDO EL CONTADOR DE VIDAS DE LA LAMPARA LLEGA A 0 SE DESENCADENA LA ANIMACION DE MUERTE

            HA.Play(HeadAttack.name); 
        }
    }

    private void OnTriggerEnter(Collider other)//Cuando se acerca sin las máscaras a alguno de los enemigos
    {
        Debug.Log("GetOutofHere: " + other.name); 

        if (other.gameObject.tag == ("Harlute") || other.gameObject.tag == ("Marlute") || other.gameObject.tag == ("Sundel") || other.gameObject.tag == ("Metatron"))
        {
            
            Player.transform.Translate(0,0,-distanciaEmpujon);      //SE TELETRANSPORTA PARA DAR LA SENSACIÓN DE QUE HA SIDO EMPUJADO Y NO PUEDE PASAR

            

            //HeadsAnimator.Play("Attack");
        }
    }


}

// CONTROLES SIMPLE DE TERCERA PERSONA              //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;           
                                                    //var z = Input.GetAxis("Vertical") * Time.deltaTime * 50.0f;

                                                       //transform.Rotate(0, x, 0);
                                                        //transform.Translate(0, 0, z); 

                                                            //public float speed = 1.0f; 