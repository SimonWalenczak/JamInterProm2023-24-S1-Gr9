using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{

    float ActualTimer;
    public VideoPlayer videoplayer;
    public VideoClip video1;
    public VideoClip video2;
    void Start()
    {
        

    }

    private void Update()
    {

        if (videoplayer.clip == video1)
        {

            ActualTimer += Time.deltaTime;
            if (ActualTimer >= 5)
            {
                ActualTimer = 0;
                videoplayer.clip = video2;
            }
        }

    }

    public void OnMouseDown()
    {
        videoplayer.clip = video1;
    }


}

