
using UnityEngine;

public class bulletProperties : MonoBehaviour
{
    private Transform target;

    public float projectileSpd = 5f;

    public void Chase (Transform _target)
    {
        target = _target;
    }
  
    // Update is called once per frame
    void Update()
    {
       
        if (target == null)
        {
            Destroy(gameObject);
            return; 
        }

        Vector3 dir = target.position - transform.position;
        float travelDistance = projectileSpd * Time.deltaTime;

        
        
        transform.Translate(Vector3.forward * travelDistance, Space.Self);

    }


    public float knockBack = 15f; 


    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {

            Destroy(gameObject);

            Debug.Log("PewPew");

            
            
        }
    }
}
