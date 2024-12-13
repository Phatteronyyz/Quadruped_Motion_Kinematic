using UnityEngine;

public class TWODOF : MonoBehaviour
{
    [Header("Joints and End Effector")]
    public Transform joint1; 
    public Transform joint2; 
    public Transform endEffector; 

    [Header("Parameters")]
    public float joint1Length = 1.0f; 
    public float joint2Length = 1.0f;
    public float targetAngle1 = 0.0f; 
    public float targetAngle2 = 0.0f; 

    [Header("Animation Settings")]
    public float rotationSpeed1 = 45.0f; 
    public float rotationSpeed2 = 90.0f;

    private float currentAngle1 = 0.0f; 
    private float currentAngle2 = 0.0f; 

    void Update()
    {
        currentAngle1 = Mathf.MoveTowards(currentAngle1, targetAngle1, rotationSpeed1 * Time.deltaTime);
        currentAngle2 = Mathf.MoveTowards(currentAngle2, targetAngle2, rotationSpeed2 * Time.deltaTime);

        joint1.localRotation = Quaternion.Euler(0, currentAngle1, 0);

        joint2.localRotation = Quaternion.Euler(0, currentAngle2, 0);
    }

    public void SetTargetAngles(float angle1, float angle2)
    {
        targetAngle1 = angle1;
        targetAngle2 = angle2;
    }
}
