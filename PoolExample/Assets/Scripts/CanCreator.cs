using UnityEngine;

public class CanCreator : MonoBehaviour
{
    [SerializeField]
    float timeSpawn;
    float currentTime;

    [SerializeField]
    GameObject prefab;


    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeSpawn)
        {
            Instantiate(prefab);
            currentTime = 0;
        }
    }
}
