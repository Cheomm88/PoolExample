using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanPool : MonoBehaviour
{
    public static CanPool instance;

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    int maxElements;

    Stack<GameObject> pool = new Stack<GameObject>();


    void Awake()
    {
        if (CanPool.instance == null)
        {
            CanPool.instance = this;
        }
        else
        {
            Destroy(this);
        }

        for (int i = 0; i < maxElements; i++)
        {
            GameObject lata = Instantiate(prefab);
            lata.SetActive(false);
            pool.Push(lata);
        }
    }

    public GameObject PopObject()
    {
        GameObject objectToReturn = null;
        if (pool.Count != 0)
        {
            objectToReturn = pool.Pop();
            //Reiniciamos la lata en su posición
            objectToReturn.transform.position = Vector3.zero;
            objectToReturn.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
        else
        { 
            objectToReturn = Instantiate(prefab);
            objectToReturn.SetActive(false);
        }

        return objectToReturn;
    }

    public void PushObject(GameObject obj)
    { 
        obj.SetActive(false);
        pool.Push(obj);
    }

    
}
