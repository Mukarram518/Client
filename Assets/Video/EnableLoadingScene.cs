using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnableLoadingScene : MonoBehaviour
{

    public GameObject Loadingimage;
    public GameObject Video;
    // Start is called before the first frame update
    void Start()
    {
        Loadingimage.SetActive(false);
        Invoke("vide", 20f);
    }

    private void vide()
    {
        Video.SetActive(false);
        Loadingimage.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
