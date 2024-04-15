using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehaivour : MonoBehaviour
{
    private MobBehaivour mobBeh;
    public Animator animator;

    private void Start()
    {
        mobBeh = (MobBehaivour)FindObjectOfType(typeof(MobBehaivour));
    }


    private void FixedUpdate()
    {
        if(mobBeh.move)
        {
            animator.SetBool("isMove", true);
        }
    }
}
