using System;
using UnityEngine;

namespace _Assets.Scripts
{
    public class CuttingCounterVisual : MonoBehaviour
    {

        [SerializeField] private CuttingCounter cuttingCounter;
        private const string CUT = "Cut";
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            cuttingCounter.OnCut += CuttingCounter_OnCut;
        }

        private void CuttingCounter_OnCut(object sender, EventArgs e)
        {
            animator.SetTrigger(CUT);
        }

    }
}
