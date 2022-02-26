using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Menu : MonoBehaviour
{
    [SerializeField]
   Button btnStart;
  

  void Start()
  {
      btnStart.onClick.AddListener(()=>{
          SceneManager.LoadScene(1); 

      });
       
   

  }
  
  
}

