using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    public RuntimeAnimatorController animatorIdle;
    public RuntimeAnimatorController animatorWalking;

    private Animator animatorCurrent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animatorCurrent = gameObject.GetComponent<Animator>();
        if (PlayerController.isIdle)
        {
            animatorCurrent.runtimeAnimatorController = animatorIdle;
        }

        if (PlayerController.isWalking)
        {
            animatorCurrent.runtimeAnimatorController = animatorWalking;
        }
    }
}
