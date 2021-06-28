using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteBangUI : MonoBehaviour
{
    [SerializeField] public float bangDuration = 0.2f;
    [SerializeField] Animator bangAnimator;

    public void Bang()
    {
        bangAnimator.SetTrigger("Bang");
    }
}
