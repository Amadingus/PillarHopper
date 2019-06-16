
using UnityEngine;

public class destructionPlatform : MonoBehaviour
{
    bool pillarTimerStarted = false;

    void OnTriggerEnter()
    {
        if (!pillarTimerStarted) pillarTimerStarted = true;
    }

    private float pillarCountdown =1.5f;


    void Update()
    {
        if (pillarTimerStarted)
        {
            pillarCountdown -= 1 * Time.deltaTime;
            Debug.Log(pillarCountdown);
        }
        if (pillarCountdown <= 0)
        {
            Destroy(gameObject);
        }
            
    }
}
