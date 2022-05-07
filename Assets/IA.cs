using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent nav;
    private float distanciaPlayer;
    private float distanciaAIpoint;
    public float distanciaPercepcao = 30;
    public float distanciadeSeguir = 20;
    public float distanciadeatacar = 2;
    public float velocidadedePasseio = 3;
    public float velocidadedeperseguicao = 6;
    public float tempoAtaque = 1.5f;
    public float dano = 40;
    public Transform[] aiPoints;
    private int aiPointAtual;
    private bool estaSeguindo;
    private bool contadorSeguindo;
    private bool atacando;
    private float cronometroSeguindo;
    private float cronometroAtaque;

    void Start()
    {
        aiPointAtual = Random.Range(0, aiPoints.Length);
        nav = transform.GetComponent<NavMeshAgent>();
    }
   
    void Update()
    {
        distanciaPlayer = Vector3.Distance(player.transform.position,transform.position);
        distanciaAIpoint = Vector3.Distance(aiPoints[aiPointAtual].transform.position, transform.position);

     


        if (distanciaPlayer > distanciaPercepcao)
        {
            Passear();
        }
        if (distanciaPlayer <= distanciaPercepcao && distanciaPlayer > distanciadeSeguir)
        {
                Olhar();
        }
        if (distanciaPlayer <= distanciadeSeguir && distanciaPlayer > distanciadeatacar)
        {
                Seguir();
                estaSeguindo =true;
           
        }
        if (distanciaPlayer <= distanciadeatacar)
        {
            Atacar();
        }

        if (distanciaAIpoint <= 2)
        {
            aiPointAtual = Random.Range(0, aiPoints.Length);
            Passear();
        }

        if (contadorSeguindo == true)
        {
            cronometroSeguindo += Time.deltaTime;
        }
        if (cronometroSeguindo >= 5 )
        {
            contadorSeguindo = false;
            cronometroSeguindo = 0;
            estaSeguindo = false;
        }

        if (atacando == true)
        {
            cronometroAtaque += Time.deltaTime;

        }
        if (cronometroAtaque >= tempoAtaque && distanciaPlayer <= distanciadeatacar)
        {
            atacando = true;
            cronometroAtaque = 0;
            VidaPlayer.vida = VidaPlayer.vida - dano;
            print("Recebeu ataque");
        }
       else if (cronometroAtaque >= tempoAtaque && distanciaPlayer > distanciadeatacar)
        {
            atacando = false;
            cronometroAtaque = 0;
            print("Errou");
        }

        
    }
    void Passear()
    {
        if (estaSeguindo == false)
        {
            nav.acceleration = 5;
            nav.speed = velocidadedePasseio;
            nav.destination = aiPoints[aiPointAtual].transform.position;

        }
        else if (estaSeguindo==true)
        {
            contadorSeguindo = true;
        }
    }
    void Olhar()
    {
        nav.speed = 0;
        transform.LookAt(player);
    }
    void Seguir()
    {
        nav.acceleration = 8;
        nav.speed = velocidadedeperseguicao;
        nav.destination = player.transform.position;
    }
    void Atacar()
    {
        atacando = true;
    }
}
