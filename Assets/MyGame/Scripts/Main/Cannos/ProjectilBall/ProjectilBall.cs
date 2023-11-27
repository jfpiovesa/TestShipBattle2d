using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilBall : MonoBehaviour
{


    [SerializeField, Space(10)] private GameObject parentThisProjectilBall;
    [SerializeField, Space(10)] private DamageObject damageObjectThisProjectilBall;
    [SerializeField, Space(10)] private float radiunsSphereOverleapCollider = 0.05f;
    public void SetUpInfo(DamageObject damageObject, GameObject parent)
    {
        damageObjectThisProjectilBall = damageObject;
        parentThisProjectilBall = parent;
    }
    private void Update()
    {
        if (damageObjectThisProjectilBall == null && parentThisProjectilBall == null) return;
      //  HitColison();
        if (GetComponent<Rigidbody2D>().velocity.magnitude < 0.1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //hit a damagable object
        IDamageObject<DamageObject> damagableObject = collision.GetComponent(typeof(IDamageObject<DamageObject>)) as IDamageObject<DamageObject>;
        if (damagableObject != null && damagableObject != (parentThisProjectilBall.gameObject.GetComponent(typeof(IDamageObject<DamageObject>)) as IDamageObject<DamageObject>))
        {
            damagableObject.Hit(damageObjectThisProjectilBall);
            GameObject vfx = Instantiate(damageObjectThisProjectilBall._prefabEfectColision, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
    void HitColison()
    {
        Collider2D[] hits = new Collider2D[0];
        hits = Physics2D.OverlapCircleAll(transform.position, radiunsSphereOverleapCollider);


        if (hits.Length > 0)
        {
            foreach (Collider2D hit in hits)
            {
                //hit a damagable object
                IDamageObject<DamageObject> damagableObject = hit.GetComponent(typeof(IDamageObject<DamageObject>)) as IDamageObject<DamageObject>;
                if (damagableObject != null && damagableObject != (parentThisProjectilBall.gameObject.GetComponent(typeof(IDamageObject<DamageObject>)) as IDamageObject<DamageObject>))
                {
                    damagableObject.Hit(damageObjectThisProjectilBall);
                    GameObject vfx = Instantiate(damageObjectThisProjectilBall._prefabEfectColision, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        Gizmos.color = transparentRed;
        Gizmos.DrawSphere(transform.position, radiunsSphereOverleapCollider);

    }
}
