using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskA : MonoBehaviour
{
    public static FlaskA instance;
    Animator animator;
    public AudioSource audioSource;
    public AudioSource audiosource1;
   

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if  (Input.GetMouseButtonDown(0))
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

    public void Shaking()
    {
        animator.SetBool("isShaking", true);
        audioSource.Play();
    }

    public void Backing()
    {
        animator.SetBool("isBacking", true);
    }

}
