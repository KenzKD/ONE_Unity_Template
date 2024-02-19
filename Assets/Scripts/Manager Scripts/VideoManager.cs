using System;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public static VideoManager Instance;
    public Video[] videos;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void PlayVideo(string name)
    {
        Video v = Array.Find(videos, x => x.name == name);
        if (v == null)
        {
            Debug.Log("Video Not Found");
        }
        else
        {
            VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
            if (videoPlayer)
            {
                string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, v.videoName);
                Debug.Log(videoPath);
                videoPlayer.url = videoPath;
                videoPlayer.Play();
            }
        }

    }
}
