using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ActionTriggerManager : MonoBehaviour
{
    [Header("Time For Action")]
    [SerializeField] private float timeToActivateTheAction = 1;

    [Space(10)]
    [Header("Awake")]
    [SerializeField] private UnityEvent actionTriggerStart;
    [Header("Start")]
    [SerializeField] private UnityEvent actionTriggerAwake;

    [Header("Layer Check Ontrigger")]
    [SerializeField] private LayerMask layerMaskOntrigger;
    [Space(10)]
    [SerializeField] private UnityEvent actionOntriggerEnter2D;
    [SerializeField] private UnityEvent actionOntriggerExit2D;
    [SerializeField] private UnityEvent actionOntriggerStay2D;



    [Header("Layer Check OnColission")]
    [SerializeField] private LayerMask layerMaskOnColission;
    [Space(10)]
    [SerializeField] private UnityEvent actionTriggerOnColissioEnter2D;
    [SerializeField] private UnityEvent actionTriggerOnColissioExit2D;
    [SerializeField] private UnityEvent actionTriggerOnColissioStay2D;


    private void Awake()
    {
        if (actionTriggerAwake == null) return;

        StartCoroutine(RequestActivateTheTimeToActivateAction(actionTriggerAwake, timeToActivateTheAction));
    }
    private void Start()
    {
        if (actionTriggerStart == null) return;

        StartCoroutine(RequestActivateTheTimeToActivateAction(actionTriggerStart, timeToActivateTheAction));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (actionOntriggerEnter2D == null) return;
        if (collision.gameObject.layer.Equals(layerMaskOntrigger)) return;

        StartCoroutine(RequestActivateTheTimeToActivateAction(actionOntriggerEnter2D, timeToActivateTheAction));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (actionOntriggerExit2D == null) return;
        if (collision.gameObject.layer.Equals(layerMaskOntrigger)) return;

        StartCoroutine(RequestActivateTheTimeToActivateAction(actionOntriggerExit2D, timeToActivateTheAction));
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (actionOntriggerStay2D == null) return;
        if (collision.gameObject.layer.Equals(layerMaskOntrigger)) return;

        StartCoroutine(RequestActivateTheTimeToActivateAction(actionOntriggerStay2D, timeToActivateTheAction));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (actionTriggerOnColissioStay2D == null) return;
        if (collision.gameObject.layer.Equals(layerMaskOnColission)) return;

        StartCoroutine(RequestActivateTheTimeToActivateAction(actionTriggerOnColissioStay2D, timeToActivateTheAction));

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (actionTriggerOnColissioStay2D == null) return;
        if (collision.gameObject.layer.Equals(layerMaskOnColission)) return;

        StartCoroutine(RequestActivateTheTimeToActivateAction(actionTriggerOnColissioStay2D, timeToActivateTheAction));
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (actionTriggerOnColissioStay2D == null) return;
        if (collision.gameObject.layer.Equals(layerMaskOnColission)) return;

        StartCoroutine(RequestActivateTheTimeToActivateAction(actionTriggerOnColissioStay2D, timeToActivateTheAction));
    }
    IEnumerator RequestActivateTheTimeToActivateAction(UnityEvent unityEvent, float time)
    {

        yield return new WaitForSeconds(time);
        unityEvent.Invoke();
    }
}

