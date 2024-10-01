using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using System.Runtime.CompilerServices;
public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
 //   [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private Canvas crossHair;

    //  ObjectPooler objectPooler;
    private Vector3 mouseWorldPosition = Vector3.zero;
    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }
    public void Start()
    {
        crossHair.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (!starterAssetsInputs.fps)
        {
            ThirdPersonState();
        }

    }

    private void ThirdPersonState() 
    {
        if (starterAssetsInputs.aim)
        {
            AimAndShoot();
            crossHair.gameObject.SetActive(true);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            crossHair.gameObject.SetActive(false);

        }
    }
 
    private void AimAndShoot()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
      //  Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit rayCastHit, 9999f, aimColliderLayerMask))
        {
            mouseWorldPosition = rayCastHit.point;
         //   hitTransform = rayCastHit.transform;
        }

        aimVirtualCamera.gameObject.SetActive(true);
        thirdPersonController.SetSensitivity(aimSensitivity);
        thirdPersonController.SetRotateOnMove(false);
        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
        

        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

        if (starterAssetsInputs.shoot)
        {

             Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;

             GameObject bullet = ObjectPool.instance.GetPooledObjectOne();
             if (bullet != null) 
             {
                 bullet.transform.position = spawnBulletPosition.position;
                 bullet.transform.rotation = Quaternion.LookRotation(aimDir,Vector3.up);
                 bullet.SetActive(true);

             }
            starterAssetsInputs.shoot = false;
        }
    }
}


