using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CerrarVideo : MonoBehaviour
{
    public VideoPlayer video;
    // Start is called before the first frame update
    
    
    
    void Start()
    {
        video.loopPointReached += OnVideoEnd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnVideoEnd(VideoPlayer vp){
         SceneManager.LoadScene("MenuPrincipal");

    }
}
