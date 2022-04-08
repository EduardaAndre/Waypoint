using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    //coordenadas dos pontos
    public GameObject[] waypoints;
    int currentWP = 0;//Nesta parte, est� definido o ponto onde est� 
    
    float speed = 1.0f;//velocidade
    float accuracy = 1.0f;//precis�o
    float rotSpeed = 0.4f;//velocidade
    
    void Start()
    {
        // todos os objetos que tiver a tag "waypoint", vai ser colocado dentro do array
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }
   
    void LateUpdate()
    {
        //a lista ta vazia? ignora todo o resto do m�todo
        if (waypoints.Length == 0) return;
        //Igonora o y e pega a posi��o do waypoint
        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x,
        this.transform.position.y,
        waypoints[currentWP].transform.position.z);
        //pega a dire��o e rotaciona o objeto pro proximo waypoint
        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
        Quaternion.LookRotation(direction),
        Time.deltaTime * rotSpeed);
        //verifica se o objeto est� no waypoint atual 
        if (direction.magnitude < accuracy)
        {
            //O pr�ximo caminho(waypoint) passa a ser o atual, ter a mesma posi��o
            currentWP++;
            //Aqui verifica se chegou no �ltimo waypoint
            if (currentWP >= waypoints.Length)
            {
                //se sim, ele volta para o primeiro lugar que chegou
               
                currentWP = 0;
            }
        }
        //Fazendo a movimenta��o  
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
    
