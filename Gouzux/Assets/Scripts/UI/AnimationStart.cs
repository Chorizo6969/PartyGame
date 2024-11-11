using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStart : MonoBehaviour
{
    [SerializeField]
    private Animation _start;

    public static AnimationStart Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _start.Play();
    }

    public void MakeAnimation(AnimationClip newClip)
    {
        _start.clip = newClip;
        _start.Play();
    }
}
