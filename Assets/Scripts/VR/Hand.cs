using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    private Animator _animator;

    private float _triggerTarget;
    private float _gripTarget;
    private float _gripCurrent;
    private float _triggerCurrent;

    public float animationSpeed;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";

    void Start()
    {

        _animator = GetComponent<Animator>();
        //_mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        AnimateHand();
    }

    internal void SetGrip(float v)
    {
        _gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        _triggerTarget = v;
    }

    void AnimateHand()
    {
        if (_gripCurrent != _gripTarget)
        {
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * animationSpeed);
            //_animator.SetFloat(animatorGripParam, _gripCurrent);
            _animator.SetFloat(animatorTriggerParam, _gripCurrent);

        }

        if (_triggerCurrent != _triggerTarget)
        {
            _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget, Time.deltaTime * animationSpeed);
            //_animator.SetFloat(animatorTriggerParam, _triggerCurrent);
            _animator.SetFloat(animatorGripParam, _triggerCurrent);

        }
    }











    //public float animationSpeed;
    //private Animator _animator;
    //private SkinnedMeshRenderer _mesh;
    //private float _triggerTarget;
    //private float _gripTarget;
    //private float _gripCurrent;
    //private float _triggerCurrent;
    //private const string animatorGripParam = "Grip";
    //private const string animatorTriggerParam = "Trigger";
    //private static readonly int Grip = Animator.StringToHash(animatorGripParam);
    //private static readonly int Trigger = Animator.StringToHash(animatorTriggerParam);

    /*
    // Physics Movement
    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform _followTarget;
    private Rigidbody _body;

    void Start()
    {
        // Animation
        //_animator = GetComponent<Animator>();
        //_mesh = GetComponentInChildren<SkinnedMeshRenderer>();

        // Physics Movement
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;

        // Teleport hands
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;

    }


    void Update()
    {
        //AnimateHand();

        PhysicsMove();
    }

    private void PhysicsMove()
    {


        // Position
        //var positionWithOffset = _followTarget.position + positionOffset;
        var positionWithOffset = _followTarget.TransformPoint(positionOffset);
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

        // Rotation
        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);

    }
    */

    /*
    internal void SetGrip(float v)
    {
        _gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        _triggerTarget = v;
    }

    void AnimateHand()
    {
        if(_gripCurrent != _gripTarget)
        {
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * animationSpeed);
            _animator.SetFloat(animatorGripParam, _gripCurrent);
        }

        if (_triggerCurrent != _triggerTarget)
        {
            _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget, Time.deltaTime * animationSpeed);
            _animator.SetFloat(animatorTriggerParam, _triggerCurrent);
        }
    }*/

}
