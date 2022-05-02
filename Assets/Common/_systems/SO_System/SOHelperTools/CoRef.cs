﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoRef : MonoBehaviour
{
    public static CoRef instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public static void CreateCorotineReferance()
    {
        if (!instance)
        {
            GameObject gameObject = new GameObject("GameEventCorotuineStarter");
            instance = gameObject.AddComponent<CoRef>();
        }
    }

    public static Coroutine StartCoroutineAway(IEnumerator action)
    {
#if !UNITY_EDITOR
        if (!instance) CreateCorotineReferance();
        return instance.StartCoroutine(action);
#else
        if (Application.isPlaying)
        {
            if (!instance) CreateCorotineReferance();
            return instance.StartCoroutine(action);
        }
        else
        {
            return null;
        }
#endif
    }

    internal static void StopCoroutineAway(Coroutine co)
    {
        if (co != null) try { instance.StopCoroutine(co); } catch (Exception e) { Debuger.LogWarning(e.Message); };
    }
}
