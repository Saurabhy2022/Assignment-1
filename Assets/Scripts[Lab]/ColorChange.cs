using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public static ColorChange instance;
    private MeshRenderer mRenderer;
    [SerializeField] private Material newMaterial1;
    [SerializeField] private Material newMaterial2;

    private void Awake()
    {
        
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

      
        mRenderer = gameObject.GetComponent<MeshRenderer>();
        if (mRenderer == null)
        {
            
        } 
    }

    public void Mesh()
    {
        if (mRenderer != null)
        {
            Material[] defaultMat = mRenderer.materials;

            if (defaultMat.Length >= 2)
            {
                defaultMat[0] = newMaterial1;
                defaultMat[1] = newMaterial2;
                Debug.Log("Materials updated successfully.");
            }
            mRenderer.materials = defaultMat;
        }
    }
}
