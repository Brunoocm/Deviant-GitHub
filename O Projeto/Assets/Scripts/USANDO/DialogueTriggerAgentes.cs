using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerAgentes : MonoBehaviour
{

	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManagerAgentes>().StartDialogue(dialogue);
	}

}
