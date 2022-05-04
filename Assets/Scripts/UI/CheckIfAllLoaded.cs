using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfAllLoaded : MonoBehaviour
{
    public List<LoadImages> LoadImagesScripts;
    public List<LoadImages> LoadImagesScriptsLoaded;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < LoadImagesScripts.Count; i++)
        {
            if (LoadImagesScripts[i].imgsLoaded)
            {
                LoadImagesScriptsLoaded.Add(LoadImagesScripts[i]);
                LoadImagesScripts[i].externalLoad.externallyLoaded= true;
                LoadImagesScripts[i].externalLoad.vidsLoadedPreviously = true;
                LoadImagesScripts[i].externalLoad.externallyLoaded = true;
                if(LoadImagesScripts[i].gameObject.tag == "Respawn")
                    LoadImagesScripts[i].externalLoad.images2 = LoadImagesScripts[i].images;
                else
                    LoadImagesScripts[i].externalLoad.images = LoadImagesScripts[i].images;


                LoadImagesScripts.Remove(LoadImagesScripts[i]);
            }
        }

        if(LoadImagesScripts.Count == 0)
            this.enabled = false;
        else
            time += Time.deltaTime;
    }
}
