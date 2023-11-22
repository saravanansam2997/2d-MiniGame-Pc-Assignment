using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float MinSpeed, MaxSpeed, SpeedMultiplier;
    private float CurrentSpeed;
    public GameObject ObstacleObj;

   
    public void ObstacleControllerStart(){
         CurrentSpeed = MinSpeed;
        GenerateObstacle();
    }
    void GenerateObstacle()
    {
        GameObject go = Instantiate(ObstacleObj, transform.position, transform.rotation);
        go.GetComponent<ObstacleHandler>().obstacleControllerCS = this;
    }
    public void GenerateObstacleNext()
    {
        float randomwait = Random.Range(0.5f, 1.2f);
        Invoke("GenerateObstacle", randomwait);
    }
    public float GetCurrentSpeed()
    {
        return CurrentSpeed;
    }

    void Update()
    {
        if (CurrentSpeed < MaxSpeed)
        {
            CurrentSpeed += SpeedMultiplier;
        }
    }
}
