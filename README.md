# Simple Dialogue System for Unity

Hello! I wanted to share some of my work starting today! You will learn how to create a simple dialogue system with [Unity Coroutines](https://docs.unity3d.com/Manual/Coroutines.html) and [ScriptableObjects.](https://docs.unity3d.com/Manual/class-ScriptableObject.html)

## Using ScriptableObject

Create a ScriptableObject on Project folder using **Create > ScriptableObjects > DialogueSystem**

![Scriptable Object Example](https://i.imgur.com/turtXIL.png)

## Script side

Make it single system:

```c#
// Make sure to drag the scriptable object here!
[SerializeField]
private DialogueSystem dialogueSystem;

//...

void Start()
{
   StartCoroutine(StartDialogue);
}

private IEnumerator StartDialogue()
{
    // Get first dialog
    var firstDialog = dialogueSystem.contexts[0].dialogue;

    // Or loop through
    for(int i=0;i<dialogue.contexts.length;i++)
    {
        var dialogue = dialogueSystem.contexts[i].dialogue;
        yield return new WaitForSeconds(dialogueSystem.contexts[i].contextReadTime);
    }
     
    // ...
}
```

Or if you want to create sequences, make it an array:

```c#
[SerializeField]
private DialogueSystem[] dialogueSystems;

//...
int currentSequence=0;

void Start()
{
   StartCoroutine(StartDialogue());
}

private IEnumerator StartDialogue()
{
    // Get sprite for talking person
    var talkerSprite = dialogueSystem[currentSequence].talkerSprite;

    // Or loop through
    for(int i=0;i<dialogue.contexts.length;i++)
    {
        var dialogue = dialogueSystem.contexts[i].dialogue;
        yield return new WaitForSeconds(dialogueSystem.contexts[i].contextReadTime);
    }
     
    // ...
}
```

If you want to divide sprites for each dialogue, simply move `public Sprite talkerSprite` inside `Context` class. 

Check out the full example [here.](ExampleDialogueSystem.cs)
