using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private SliderJoint2D sliderJoint;
    private JointMotor2D motor;

    public float speed;
    public float upperLimit;
    public float lowerLimit;

    private void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        motor = sliderJoint.motor;
    }

    private void Update()
    {
        if (sliderJoint.jointTranslation < upperLimit)
        {
            motor.motorSpeed = speed;
            sliderJoint.motor = motor;
        }
        else if (sliderJoint.jointTranslation > lowerLimit)
        {
            motor.motorSpeed = -speed;
            sliderJoint.motor = motor;
        }
        else
        {
            motor.motorSpeed = 0f;
            sliderJoint.motor = motor;
        }
    }
}
