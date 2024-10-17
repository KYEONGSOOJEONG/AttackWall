using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerActive : MonoBehaviour
{
    public GameObject power;
    public GameObject wayMoveDir;

    // Start is called before the first frame update
    void Start()
    {
        power.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            power.gameObject.SetActive(true);
            wayMoveDir.gameObject.SetActive(false);
        }
    }
}
