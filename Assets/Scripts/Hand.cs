using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : XRDirectInteractor
{

    public MeshRenderer handRenderer;

    protected override void Awake()
    {
        base.Awake();
    }

    public void SetVisibility(bool value)
    {
        this.handRenderer.enabled = value;
    }
}
