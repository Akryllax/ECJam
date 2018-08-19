using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : ExMono {

    public float MoveSpeedX = 2, MoveSpeedY = 2;

    public float MaxX, MaxY;
    public Transform target;
    public Rigidbody targetRigidbody;
    public Camera mainCamera;

    private Rigidbody[] rigidbodies;
    private Collider[] colliders;

    [SerializeField]
    private HitSoundManager sfxManager;

    public static PlayerEntity instance;

    public void Start()
    {
        if(instance)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }

        Rect rect = ExMono.GetScreenRect();

        MaxX = rect.width * 0.33f;
        MaxY = rect.height * 0.33f;

        rigidbodies = targetRigidbody.GetComponentsInChildren<Rigidbody>();
        colliders = targetRigidbody.GetComponentsInChildren<Collider>();


        foreach (Collider col in colliders)
        {

        }
    }

    // Use this for initialization
    public void TickInputVector(Vector2 inputVector)
    {
        Vector3 forwardProj = Vector3.forward;
        Vector3 rightProj = Vector3.ProjectOnPlane(mainCamera.transform.right, Vector3.up).normalized;

        this.transform.position += (forwardProj * inputVector.y * MoveSpeedY + rightProj * inputVector.x * MoveSpeedX) * Time.deltaTime;
    }

    public void PlayHitSound()
    {
        sfxManager.PlayGrunt();
    }
}
