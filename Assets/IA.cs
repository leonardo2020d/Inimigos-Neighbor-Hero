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
    private bool atacando;

    private float cronometroAtaque;

    void Start()
    {
        aiPointAtual = Random.Range(0, aiPoints.Length);
        nav = transform.GetComponent<NavMeshAgent>();
    }
   
    void Update()
    {
        //Pega a distancia do player em relação a IA
        distanciaPlayer = Vector3.Distance(player.transform.position,transform.position);
        //pega a distancia do Ai Point atual em relação a IA
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
            // escolhe outro AI point aleatório para o player seguir 
            aiPointAtual = Random.Range(0, aiPoints.Length);
            Passear();
        }

       

        if (atacando == true)
        {
            //inicia o contador para que n fique atacando toda hora
            cronometroAtaque += Time.deltaTime;

        }
        if (cronometroAtaque >= tempoAtaque && distanciaPlayer <= distanciadeatacar)
        {
            // zera o cronometro para que o inimogo possa atacar dnv
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
