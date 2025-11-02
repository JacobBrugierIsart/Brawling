using System.Collections;
using System.Timers;
using UnityEngine;

public class Enemy : Move
{
    private bool IsHitable = true;
    void Start()
    {
          m_Direction = new Vector3(1, 0, 1);

    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter(Collider pOther)
    {
        if (pOther.CompareTag("Weapon"))
        {
            if (!IsHitable) return;
            Weapon lWeapon = pOther.gameObject.GetComponentInParent<Weapon>();
            Ray lRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit lHit;
            Vector3 lMousePos = Vector3.zero;

            if (Physics.Raycast(lRay, out lHit))
            {
                lMousePos = lHit.point;
            }

            Vector3 lX = m_Direction;
            Vector3 lK = Vector3.Cross((pOther.transform.position - lMousePos).normalized, Vector3.up);

            Vector3 lVectorReflexion = (lX - 2 * (Vector3.Dot(lX, lK)) * lK);

            Vector3 lVectorNormal = lK;

            m_Direction = ((m_Speed/(lWeapon.ActualSpeed + m_Speed)) * lVectorReflexion + (lWeapon.ActualSpeed/(m_Speed + lWeapon.ActualSpeed)) * lVectorNormal).normalized;

            StartCoroutine(nameof(HitableCoolDown));
        }

        if (pOther.CompareTag("Wall"))
        {
            m_Direction = -m_Direction;
        }
    }

    private IEnumerator HitableCoolDown()
    {
        IsHitable = false;
        yield return new WaitForSeconds(.8f);
        IsHitable = true;
    }
}
