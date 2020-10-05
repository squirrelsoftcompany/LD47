using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

namespace UI
{
    public class EndScreen : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !Dora.Inst.gameState.running)
                Restart();
        }

        public void Show()
        {
            Image endImage = gameObject.GetComponent<Image>();
            if(endImage)
            {
                endImage.enabled = true;
            }
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void BackToMenu()
        {
            Dora.Inst.gameState.showMainScreen = true;
            Restart();
        }

    }
}