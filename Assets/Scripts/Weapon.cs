using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : XRGrabInteractable
{
    public GameObject fireEffect; 
    public Transform gunTip;
    public AudioSource audioSource;
    public AudioClip powpow;
    public GameObject bulletLine;
    public float weaponDamage;

    public LayerMask enemyLayerMask;

    protected override void Awake()
    {
        base.Awake();

    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
    }

    public void PullTrigger(XRBaseInteractor interactor)
    {
        var controller = interactor.GetComponent<XRController>();
        controller.SendHapticImpulse(1, 0.08f);
        Destroy(Instantiate(fireEffect, gunTip.position, gunTip.rotation), 0.5f);

        DrawLine();

        audioSource.PlayOneShot(powpow,1);
        DoTheDamage();
    }

    public void DrawLine() {

        var line = Instantiate(bulletLine, gunTip.position, gunTip.rotation);
        var lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, gunTip.position);
        lineRenderer.SetPosition(1, gunTip.position + gunTip.rotation * Vector3.forward * 100);
        Destroy(line, 0.05f);
    }
    public void EraseLine() { 
    
    
    }

    public void DoTheDamage(){
        Debug.DrawRay(gunTip.position, gunTip.rotation * Vector3.forward, Color.red, 1);
        if (Physics.Raycast(gunTip.position, gunTip.rotation * Vector3.forward, out RaycastHit hitinfo, 100, enemyLayerMask)) {
            var enemy = hitinfo.collider.GetComponent<Enemy>();
            enemy.DoDamage(weaponDamage, hitinfo.collider);
        };
    }

    public void ApplyRecoil()
    {
       
    }
}
