using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class CoblosContainer : MonoBehaviour
{
    public GameObject selected { get; set; }
    public Vector2 newPos { get; set; }
    private GameObject alat;
    private Animator alatAnimator;
    private GameObject lubang;
    AnimatorClipInfo[] _CurrentClipInfo;

    public Components components;

    private void Awake()
    {
        alat = components.alat;
        lubang = components.lubang;

        alatAnimator = alat.GetComponentInChildren<Animator>();
    }

    public void onNyoblos()
    {
        StartCoroutine(PlayNyoblos());
    }

    IEnumerator PlayNyoblos()
    {
        alatAnimator.SetTrigger("play");
        //_CurrentClipInfo = alatAnimator.GetCurrentAnimatorClipInfo(0);

        //Debug.Log(_CurrentClipInfo[0]);
        yield return new WaitForSeconds(0.55f);

        lubang.transform.position = newPos;
    }

    [Serializable]
    public class Components
    {
        public GameObject alat;
        public GameObject lubang;
    }
}
