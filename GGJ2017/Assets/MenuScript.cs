using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;

    private void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
    }
}
