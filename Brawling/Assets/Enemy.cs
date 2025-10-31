using UnityEngine;

public class Enemy : Move
{
    void Start()
    {
          m_Direction = new Vector3(1, 0, 0);
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter(Collider pOther)
    {
        if (pOther.CompareTag("Weapon"))
        {
            //JSP MDRRRR
        }

        if (pOther.CompareTag("Wall"))
        {
            m_Direction = -m_Direction;
        }

    }
}
