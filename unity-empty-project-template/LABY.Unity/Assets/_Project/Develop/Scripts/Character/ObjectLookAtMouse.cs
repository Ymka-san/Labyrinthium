using UnityEngine;

namespace _Project.Develop.Scripts.Character
{
    public class ObjectLookAtMouse : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Camera _camera;
       
        
        private void Update()
        {
            Vector3 pointToLookAt = LookAtMouse();
            if (pointToLookAt != Vector3.zero)
            {
                // Поворачиваем персонажа только по оси Y
                Vector3 direction = new Vector3(pointToLookAt.x, transform.position.y, pointToLookAt.z);
                transform.LookAt(direction);
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
        
        
    }
}