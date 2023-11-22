using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    public ObstacleController obstacleControllerCS;

    void Update()
    {
        transform.Translate(Vector2.left * obstacleControllerCS.GetCurrentSpeed() * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("StartLine"))
        {
            GameManager.Instance.ScoreCalc();
            Destroy(this.gameObject);

        }
        else if (other.gameObject.CompareTag("EndLine"))
        {
            obstacleControllerCS.GenerateObstacleNext();
        }

    }
}
