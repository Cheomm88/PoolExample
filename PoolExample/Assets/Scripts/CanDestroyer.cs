using UnityEngine;

public class CanDestroyer : MonoBehaviour
{
    [SerializeField]
    float timeDelete = 4f;
    float currentTime;

   
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeDelete)
        { 
           Destroy(gameObject);        
        }
    }
}
