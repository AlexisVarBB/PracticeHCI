using UnityEngine;

public class Tilt : MonoBehaviour
{
    public float tiltAngle = 15f; 
    public float tiltSpeed = 2f;  
    public float changeInterval = 10f; 

    private float timer;
    private Quaternion targetRotation;

    void Start()
    {
        SetNewTargetRotation();
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= changeInterval)
        {
            SetNewTargetRotation();
            timer = 0;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * tiltSpeed);
    }

    void SetNewTargetRotation()
    {
        float x = Random.Range(-tiltAngle, tiltAngle);
        float z = Random.Range(-tiltAngle, tiltAngle);
        targetRotation = Quaternion.Euler(x, 0, z);
    }
}