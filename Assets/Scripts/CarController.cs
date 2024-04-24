using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CarController : MonoBehaviour, IDataPersistance
{

    [System.Serializable]
    public struct Wheel
    {
        public WheelCollider collider;
        public Transform transform;
    }
    [System.Serializable]
    public struct Axle
    {
        public Wheel leftWheel;
        public Wheel rightWheel;
        public bool isMotor;
        public bool isSteering;
    }
    [SerializeField] Axle[] axles;
    [SerializeField] float maxMotorTorque;
    [SerializeField] float maxSteeringAngle;

    public void FixedUpdate()
    {
        float motor = Input.GetAxis("Vertical") * maxMotorTorque;
        float steering = Input.GetAxis("Horizontal") * maxSteeringAngle;
        foreach (Axle axle in axles)
        {
            if (axle.isSteering)
            {
                axle.leftWheel.collider.steerAngle = steering;
                axle.rightWheel.collider.steerAngle = steering;
            }
            if (axle.isMotor)
            {
                axle.leftWheel.collider.motorTorque = motor;
                axle.rightWheel.collider.motorTorque = motor;
            }
            UpdateWheelTransform(axle.leftWheel);
            UpdateWheelTransform(axle.rightWheel);
        }
    }

    public void UpdateWheelTransform(Wheel wheel)
    {
        wheel.collider.GetWorldPose(out Vector3 position, out Quaternion rotation);
        wheel.transform.position = position;
        wheel.transform.rotation = rotation;
    }

    public void LoadData(GameData data)
    {
        transform.position = data.playerPos;
        transform.rotation = data.playerRot;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPos = transform.position;
        data.playerRot = transform.rotation;
    }
}