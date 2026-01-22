using UnityEngine;

public class CanReturner : MonoBehaviour
{
    [SerializeField]
    float timeDelete = 4f;
    float currentTime;


    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeDelete)
        {
            currentTime = 0.0f;
            CanPool.instance.PushObject(gameObject);
        }
    }
}
