using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageApply : MonoBehaviour
{
    public RawImage rawTest;
    public Texture testTexture;

    // Start is called before the first frame update
    void Start()
    {
        rawTest.texture = testTexture;    
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < textures.Count; i++)
        //{
        //    textures = liScript.images;
        //    GameObject prefab = Instantiate(p, transform.position, Quaternion.identity);
        //    prefab.GetComponent<RawImage>().texture = textures[i];
        //}
    }
}
