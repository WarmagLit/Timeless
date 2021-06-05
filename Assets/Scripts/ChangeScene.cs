using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;                 

public class ChangeScene : MonoBehaviour
{
    public void ChooseScene(int a)                  // Метод смены сцены с номером сцены
    {
        SceneManager.LoadScene(a);                  // Выбор сцены 
    }

    public void Exit()                              // Метод выхода из приоложения
    {
        Application.Quit();                         // Сам выход
    }

}