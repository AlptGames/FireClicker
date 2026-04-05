using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Start()
    {
        // Скрываем стандартный системный курсор
        Cursor.visible = false;
    }

    void Update()
    {
        // Получаем позицию мыши в экранных координатах
        Vector3 mousePos = Input.mousePosition;

        // Переводим их в мировые координаты для 2D
        mousePos.z = 10; // Дистанция от камеры
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Обновляем позицию объекта
        transform.position = worldPos;
    }
}
