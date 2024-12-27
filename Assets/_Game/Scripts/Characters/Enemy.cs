using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private bool _hasTarget = false;

    public virtual bool HasTarget {
        get {return _hasTarget; }
        protected set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }
}
