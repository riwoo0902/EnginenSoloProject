using System;
using _1.Script.EntityScript.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _1.Script.UI
{
    public class ResetButton : MonoBehaviour
    {


        public void Reset123()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}