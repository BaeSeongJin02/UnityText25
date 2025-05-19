using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTartget : MonoBehaviour
{
    public GameObject targetPrefab;

    Transform[] destinations;
    // Start is called before the first frame update
    void Start()
    {
        destinations = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
