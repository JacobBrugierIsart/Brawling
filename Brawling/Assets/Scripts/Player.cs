using Unity.Android.Gradle;
using UnityEngine;

public class Player : Move
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private string _HorizontalAxis = "Horizontal";
    private string _VerticalAxis = "Vertical";

    private float LookSpeed = 20f;

    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        m_Direction = (Input.GetAxis(_HorizontalAxis) * Vector3.right + Input.GetAxis(_VerticalAxis) * Vector3.forward).normalized;
        LookMouse();
    }

    private void LookMouse()
    {
        Ray lRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit lHit;

        if (Physics.Raycast(lRay, out lHit))
        {
            Vector3 lPointACibler = lHit.point;

            lPointACibler.y = transform.position.y;

            Vector3 lDirection = lPointACibler - transform.position;

            if (lDirection != Vector3.zero)
            {
                Quaternion lRotationCible = Quaternion.LookRotation(lDirection, Vector3.up);

                transform.rotation = Quaternion.Slerp(transform.rotation, lRotationCible, Time.deltaTime * LookSpeed);
            }
        }
    }
}
