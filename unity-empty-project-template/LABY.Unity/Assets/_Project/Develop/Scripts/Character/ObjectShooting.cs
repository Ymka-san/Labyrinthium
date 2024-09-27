using System.Collections;
using System.Collections.Generic;
using _Project.Develop.Scripts.Character;
using UnityEngine;

public class ObjectShooting : MonoBehaviour, IShooting
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private LayerMask groundLayer;
    

    private void Update()
    {
        Vector3 pointToLookAt = LookAtMouse();
        if (Input.GetMouseButtonDown(0)) // ЛКМ
        {
            Shoot(pointToLookAt);
        }
    }
    
    private Vector3 LookAtMouse()
    {
        // Создаем луч из камеры по направлению курсора
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        // Переменная для хранения информации о том, куда попал луч
        RaycastHit hit;

        // Выполняем проверку пересечения луча с землей
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            return hit.point; // Возвращаем точку пересечения с землей
        }

        return Vector3.zero; // Если луч не попал в землю, возвращаем ноль
    }
    public void Shoot(Vector3 targetPoint)
    {
        
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // Рассчитываем направление выстрела
        Vector3 shootDirection = (targetPoint - shootPoint.position).normalized;

        // Добавляем движение пуле
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;
        
        
    }
    
    
}
