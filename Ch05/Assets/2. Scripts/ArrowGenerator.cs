using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float span = 1.0f;
    float delta = 0f;


    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if(delta > span)
        {
            GameObject go = Instantiate(arrowPrefab);
            int px = Random.Range(-8, 9);
            go.transform.position = new Vector3(px, 6.4f, 0);

            delta = 0;
        }
    }
}
