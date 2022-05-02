using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbitObject : MonoBehaviour
{
    public bool orbit;
    public List<string> videos = new List<string>();
    public GameObject prefab;
    public List<GameObject> objects = new List<GameObject>();
    public float radius;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects(radius, videos);
    }

    // Update is called once per frame
    void Update()
    {
        if (orbit)
        {
            StartCoroutine(RotateMe(new Vector3(0,0,1) * 90, time));
            orbit = false;
        }
    }

    public void SpawnObjects(float radius, List<string> videos)
    {
        for (int i = 0; i < videos.Count; i++)
        {
            float theta = i * 2 * Mathf.PI / videos.Count;
            float x = Mathf.Sin(theta) * radius;
            float y = Mathf.Cos(theta) * radius;
        

            GameObject ob = Instantiate(prefab);
            ob.transform.parent = transform;
            ob.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
            Debug.Log(videos[i]);
            ob.GetComponent<AssignRenderTexture>().videoURL = videos[i];
            objects.Add(ob);
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

    public void SpinInClosedSpace()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            
        }
    }

    //public void Orbit(GameObject obj, float speed)
    //{
    //    Vector3 pointT = new Vector3(5, 0, 0);
    //    Vector3 axis = new Vector3(0, 0, 1);
    //    f += Time.deltaTime * speed;


    //    obj.transform.RotateAround(transform.position, axis, f);

    //    if (f >= 1)
    //    {
    //        orbit = false;
    //    }
    //}
}
