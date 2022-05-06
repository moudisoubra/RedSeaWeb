using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIfAllLoaded : MonoBehaviour
{
    public List<LoadImages> LoadImagesScripts;
    public List<LoadImages> LoadImagesScriptsLoaded;
    public LoadImages sls;
    public float time;

    public Image loadingImage;
    public float initialCount;
    public float loadedCount;
    public PlayTransition ptScript;
    public GameObject loadingParent;
    // Start is called before the first frame update
    void Start()
    {
        initialCount = LoadImagesScripts.Count;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < LoadImagesScripts.Count; i++)
        {
            if (LoadImagesScripts[i].imgsLoaded)
            {
                loadedCount++;
                LoadImagesScriptsLoaded.Add(LoadImagesScripts[i]);
                LoadImagesScripts[i].externalLoad.externallyLoaded= true;
                LoadImagesScripts[i].externalLoad.vidsLoadedPreviously = true;
                LoadImagesScripts[i].externalLoad.imgsLoadedPreviously = true;
                LoadImagesScripts[i].externalLoad.imgsLoaded = true;
                if (LoadImagesScripts[i].gameObject.tag == "Respawn")
                {
                    LoadImagesScripts[i].externalLoad.images2 = LoadImagesScripts[i].images;
                    LoadImagesScripts[i].activated = true;
                    LoadImagesScripts[i].enabled = true;
                }
                else
                {
                    LoadImagesScripts[i].externalLoad.images = LoadImagesScripts[i].images;
                    LoadImagesScripts[i].externalLoad.videos = LoadImagesScripts[i].videos;

                }


                LoadImagesScripts.Remove(LoadImagesScripts[i]);
            }
        }

        if(LoadImagesScripts.Count == 0)
        {
            sls.activated = true;
            sls.enabled = true;
            this.enabled = false;
        }
        else
            time += Time.deltaTime;

        loadingImage.fillAmount = loadedCount / initialCount;

        if (loadedCount == initialCount)
        {
            ptScript.enabled = true;
            loadingParent.SetActive(false);
            this.enabled = false;
        }
    }
}
