using UnityEngine;
using System.Collections;

public class EnemigoProximidad : MonoBehaviour
{
    // la capsula
    UnityEngine.AI.NavMeshAgent agent;
    // nuestro player
    // como es publica la referencia la hacemos en el entorno grafico
    public Transform target;
    // distancia mínima para cambiar la animacion
    public float proximidad;
    // el animator
    Animator animator;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        // asiganmos el animator del player para poder cambiar la bool
        animator = target.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // actualizamos la posicion de la capsula (enemy/agent)
        // con el player/target
        agent.SetDestination(target.position);
        // comparamos la distancia al enemigo
        // cambiamos la variable bool
        // de esta manera forzamos la transicion desde Tarnquilo a Peligro
        // y vice versa
        if (!agent.pathPending && agent.remainingDistance < proximidad)
        {
            Debug.Log("Peligro");
            // cambiamos a true la variable del animator
            animator.SetBool("EstarEnPeligro", true);
        }
        else
        {
            Debug.Log("Tranqui");
            // cambiamos a false la variable del animator
            animator.SetBool("EstarEnPeligro", false);
        }
    }
}