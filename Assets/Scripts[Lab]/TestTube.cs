using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTube: MonoBehaviour
{
    private MeshRenderer _Renderer;
    Animator animator;
    public AudioSource audiosource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        _Renderer = transform.Find("TestTube (2)").gameObject.GetComponentInChildren<MeshRenderer>();
    }

    void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit) && rayHit.transform == transform)
            {
                StartCoroutine("PlayAnimation");
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit) && rayHit.transform == transform)
            {
                StartCoroutine("Flaskb");
            }
        }
    }

    IEnumerator PlayAnimation()
    {   
        animator.SetBool("isMoving", true);
        audiosource.Play();
        yield return new WaitForSeconds(1f);
        _Renderer.material.SetFloat("_FillAmount", 0.6f);

        animator.SetBool("isBack", false);

        yield return new WaitForSeconds(1f);

        animator.SetBool("isBack", true);

        yield return new WaitForSeconds(1f);

        FlaskA.instance.Shaking();

        yield return new WaitForSeconds(1f);

        ColorChange.instance.Mesh();
        Debug.Log("Instance");
        
        PlayerAnimation.instance.playerAnimator.SetTrigger("isHappy");
        Debug.Log("Happy");

        yield return new WaitForSeconds(1f);

        FlaskA.instance.Backing();
    }

    IEnumerator Flaskb()
    {
        animator.SetBool("isMoving", true);
        audiosource.Play();
        yield return new WaitForSeconds(1f);
        _Renderer.material.SetFloat("_FillAmount", 0.5f);

        animator.SetBool("isBack", false);

        yield return new WaitForSeconds(1f);

        animator.SetBool("isBack", true);

        yield return new WaitForSeconds(1f);

        animator.SetBool("isMoving", true);

        FlaskB.instance.ShakingB();
        yield return new WaitForSeconds(3f);

        PlayerAnimation.instance.playerAnimator.SetTrigger("isIrritated");
        Debug.Log("Irritated");

        FlaskB.instance.BackingB();
    }


}