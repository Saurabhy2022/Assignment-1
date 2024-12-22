using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
   public static PlayerAnimation instance;
   public Animator playerAnimator;

    void Start()
    {
       playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }
}
