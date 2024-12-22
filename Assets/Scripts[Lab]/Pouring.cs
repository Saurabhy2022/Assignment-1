using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
   [SerializeField] private Material material;
    public float fillamount;

    private void Update()
    {
        if (material != null)
        {
            material.SetFloat("_FillAmount", fillamount);
        }
    }
}
   