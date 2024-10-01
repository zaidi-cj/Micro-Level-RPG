using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    QuestBaseState currentState;
    public NoQuest noQuest = new NoQuest();
    public QuestAvailable questAvailable = new QuestAvailable();
    public QuestGive questGive = new QuestGive();
    public QuestComplete questComplete = new QuestComplete();
    public Image questImage;
    public Sprite questAvailableImg;
    public Sprite questGiveImg;
    public Sprite questCompleteImg;
    Color color;
    public bool questChecked;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;

        // Unlock the cursor so it moves freely
       // Cursor.lockState = CursorLockMode.None;
        questImage = GetComponentInChildren<Image>();
        currentState = noQuest;
        currentState.EnterState(this);
        color.a = 0;
        questImage.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
 
    }

    public void SwitchState(QuestBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    public void HideImage()
    {
        color.a = 0;
        questImage.color = color;
    }
    public void ShowImage()
    {
        color.a = 1;
        color = Color.white;
        questImage.color = color;
    }
    public void CheckClick()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            // Create a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits a collider
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                // Check if the object hit is this object
                if (hit.transform == transform)
                {
                    questChecked = true;
                }
            }

        }
    }

}
