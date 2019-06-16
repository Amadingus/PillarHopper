
using UnityEngine;

public class bulletLife : MonoBehaviour
{
    public float bulletTime = 2f;

    // Update is called once per frame
    void Update()
    {

        bulletTime -= Time.deltaTime;

        if (bulletTime <= 0)
        {
            Destroy(gameObject);
        }

    }
}
