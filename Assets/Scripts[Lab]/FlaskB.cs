using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskB : MonoBehaviour
{
    public static FlaskB instance;
    public AudioSource audioSource;
    public AudioSource audioSource1;
    
    
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
       if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit) && rayHit.transform == transform)
            {
                animator.SetBool("isMoving", true);
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void ShakingB()
    {
        animator.SetBool("isShaking", true);
        audioSource1.Play();

        audioSource.Play();
    }

    public void BackingB()
    {
       animator.SetBool("isBacking", true);
    }

}
        