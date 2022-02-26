using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseRotateView : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vcam;
    private CinemachinePOV povComponent;

    // Start is called before the first frame update
    void Start()
    {
        povComponent = vcam.GetCinemachineComponent<CinemachinePOV>();
    }

    // Update is called once per frame
    void Update()
    {
        //float yRot = povComponent.m_VerticalAxis.Value;
        Vector3 currentRotation = transform.rotation.eulerAngles;

        float xRot = povComponent.m_HorizontalAxis.Value;
        transform.rotation = Quaternion.Euler(currentRotation.x, xRot, currentRotation.z);
    }
}
