using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform BaseballBatModel;

    private Vector3 AttackRange = new Vector3(120, 0, 0);
    private float AttackDuration = 0.1f;
    private bool AttackLeft;

    public float ActualSpeed;
    private float PreviousRotation = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    StopAllCoroutines();
        //    StartCoroutine(SwingBat());
        //}
        GetSpeed();
    }

    private IEnumerator SwingBat()
    {
        AttackLeft = !AttackLeft;
        Quaternion lStartRotation = BaseballBatModel.localRotation;

        Vector3 lTargetEuler = (AttackLeft ? -AttackRange : AttackRange);
        Quaternion lTargetRotation = lStartRotation * Quaternion.Euler(lTargetEuler);
        float lTimeElapsed = 0f;

        while (lTimeElapsed < AttackDuration)
        {
            float t = lTimeElapsed / AttackDuration;

            BaseballBatModel.localRotation = Quaternion.Slerp(lStartRotation, lTargetRotation, t);

            lTimeElapsed += Time.deltaTime;

            yield return null;
        }

        BaseballBatModel.localRotation = lTargetRotation;
    }

    private void GetSpeed()
    {
        float lActualRotation = GetComponentInParent<Transform>().eulerAngles.y;

        ActualSpeed = Mathf.Abs(PreviousRotation - lActualRotation);

        PreviousRotation = lActualRotation;
    }
}
