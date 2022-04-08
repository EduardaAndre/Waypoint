using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    //coordenadas dos pontos
    public GameObject[] waypoints;
    int currentWP = 0;//Nesta parte, está definido o ponto onde está 
    
    float speed = 1.0f;//velocidade
    float accuracy = 1.0f;//precisão
    float rotSpeed = 0.4f;//velocidade
    
    void Start()
    {
        // todos os objetos que tiver a tag "waypoint", vai ser colocado dentro do array
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }
   
    void LateUpdate()
    {
        //a lista ta vazia? ignora todo o resto do método
        if (waypoints.Length == 0) return;
        //Igonora o y e pega a posição do waypoint
        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x,
        this.transform.position.y,
        waypoints[currentWP].transform.position.z);
        //pega a direção e rotaciona o objeto pro proximo waypoint
        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
        Quaternion.LookRotation(direction),
        Time.deltaTime * rotSpeed);
        //verifica se o objeto está no waypoint atual 
        if (direction.magnitude < accuracy)
        {
            //O próximo caminho(waypoint) passa a ser o atual, ter a mesma posição
            currentWP++;
            //Aqui verifica se chegou no último waypoint
            if (currentWP >= waypoints.Length)
            {
                //se sim, ele volta para o primeiro lugar que chegou
               
                currentWP = 0;
            }
        }
        //Fazendo a movimentação  
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
    
