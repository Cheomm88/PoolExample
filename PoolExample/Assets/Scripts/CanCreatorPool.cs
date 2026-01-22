using UnityEngine;

public class CanCreatorPool : MonoBehaviour
{
    [SerializeField]
    float timeSpawn;
    float currentTime;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeSpawn)
        {
            GameObject lata = CanPool.instance.PopObject();
            lata.SetActive(true);

            currentTime = 0f;
        }
    }
}
