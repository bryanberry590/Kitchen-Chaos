using System;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{

    [SerializeField] private ContainerCounter containerCounter;
    private const string OPEN_CLOSE = "OpenClose";
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        containerCounter.OnPlayerGrabbedObject += CounterCounter_OnPLayerGrabbedObject;
    }

    private void CounterCounter_OnPLayerGrabbedObject(object sender, EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
