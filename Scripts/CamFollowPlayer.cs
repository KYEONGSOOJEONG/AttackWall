using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{

    public GameObject player;
    public float offsetX;
    public float offsetY;
    public float offsetZ;
    private Vector3 playerPos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //playerPos = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);
        //transform.position = Vector3.Lerp(transform.position, playerPos, Time.deltaTime * 5);
        transform.position = player.transform.position + new Vector3(0 + offsetX, offsetY + 1.0f, 0 + offsetZ);

        transform.rotation = player.transform.rotation;

        //transform.rotation = Quaternion.Euler(0, player.transform.rotation.eulerAngles.y, 0);
    }
}
