using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTarget : MonoBehaviour
{
    public GameObject targetPrefab;

    Transform[] destinations;
    // Start is called before the first frame update
    void Start()
    {
        destinations = GetComponentsInChildren<Transform>();
        Debug.Log("Num of children : " + destinations.Length);

    }

    public void GenerateTargetObject()
    {
        int index;

        index = Random.Range(1, destinations.Length);

        GameObject target = Instantiate(targetPrefab,
                                        destinations[index].position,
                                        Quaternion.identity);
        target.transform.SetParent(destinations[index]);
    }

}
