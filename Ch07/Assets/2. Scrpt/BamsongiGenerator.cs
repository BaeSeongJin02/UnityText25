using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab, 
                                              transform.position, 
                                              transform.rotation);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;

            //bamsongi.GetComponent<BamsongiController>().Shoot(new Vector3(0, 200, 2000));
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir * 2000);
        }
    }
}
