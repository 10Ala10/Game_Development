using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 tempos;
    private Transform player;
    [SerializeField]
    private float minX, maxX;
    public GameOver gameovercamera;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
        {
            return;
        }
        tempos = transform.position;
        tempos.x = player.position.x;
        tempos.x = Math.Max(tempos.x, minX);
        tempos.x = Math.Min(tempos.x, maxX);
        transform.position = tempos;

    }

}
