using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    public RuntimeAnimatorController animatorIdle; // Animator controller for when the player is idle
    public RuntimeAnimatorController animatorWalking; // Animator controller for when the player is walking

    private Animator animatorCurrent; // Variable to hold gameObject's animator controller

    // Start is called before the first frame update
    void Start()
    {
        animatorCurrent = gameObject.GetComponent<Animator>(); // Refer to current animator
    }

    // Update is called once per frame
    void Update()
    {
        // For each possible player action, a boolean marker will be set in the PlayerController script.
        // Depending ont he current state marker in PlayerController, a different Animator COntroller will be used.
        
        // When the player is idle, use the idle animation
        if (PlayerController.isIdle)
        {
            animatorCurrent.runtimeAnimatorController = animatorIdle;
        }

        // When the player is walking, use the walking animation
        if (PlayerController.isWalking)
        {
            animatorCurrent.runtimeAnimatorController = animatorWalking;
        }
    }
}
