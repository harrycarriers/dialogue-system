using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Example class to show how dialog system works
/// </summary>
public class ExampleDialogueSystem : MonoBehaviour
{
    // Create a dialog array (You have to put dialog.cs in your project folder to make this work)
    [SerializeField]
    private Dialogue[] dialogs;

    // The text field for context
    [SerializeField]
    private Text dialogTextComponent;

    // The text field for showing something like "Mike"
    [SerializeField]
    private Text dialogOwnerTextComponent;

    [SerializeField]
    // The image field for showing a picture of who is talking
    private Image dialogOwnerImageComponent;

    Coroutine dialogCoroutine;
    void Start()
    {
        // Reference coroutine to stop it and start it again later (skip feature)
        dialogCoroutine = StartCoroutine(ShowDialog());
    }

    // Call this from next dialog button
    public void NextDialog()
    {
        // Stop current coroutine and start again (so you just skipped one dialog)
        StopCoroutine(dialogCoroutine);
        dialogCoroutine = StartCoroutine(ShowDialog());
    }

    // Call this from close dialog button
    public void CloseDialog()
    {
        // If you just want to skip all dialogs, simply stop coroutine and don't start again
        StopCoroutine(dialogCoroutine);
        // Also reset contextNo
        contextNo = 0;
    }

    /// <summary>
    /// You need this to make dialogs skippable (Make it local variable on <see cref="ShowDialog"/> if you dont want to use skip).
    /// </summary>
    private int contextNo = 0;

    /// <summary>
    /// This variable determines which dialog will be used on array.
    /// </summary>
    private int dialogNo = 0;

    // The heart of this system, our coroutine <3
    private IEnumerator ShowDialog()
    {
        if (contextNo == 0)
        {
            // Change that "Unknown talker" to something elegant like "Mike the Farmer" 
            // You know, i almost choked out that how did i named dialog owner as "talker"
            dialogOwnerTextComponent.text = dialogs[dialogNo].talker;
           
            // Put some nice image for them
            dialogOwnerImageComponent.sprite = dialogs[dialogNo].talkerSprite;
        }
        // Loop current dialog for every context
        while (dialogs[dialogNo].contexts.length > contextNo)
        {
            // Get dialog context
            Dialogue.Context dialogContext = dialogs[dialogNo].contexts[contextNo];

            // Clear text component
            dialogTextComponent.text = "";

            // We are done with this context (for skip feature)
            contextNo++;

            // This loop is for dactilo effect (if you want to show text immediately, get rid of loop and add the below line)
            // dialogString.text = dialogContext.dialog;
            for (int i = 0; i < dialogContext.length; i++)
            {
                // iterating every single character eh
                dialogString.text += dialogContext.dialog[i];
                // You can specify a different value to speed up or slow down (0.05f seems nice to me)
                yield return new WaitForSeconds(0.05f);
            }

            // Specified on Dialog ScriptableObject, this is like you give the player some read time before writing next dialog
            yield return new WaitForSeconds(context.contextReadTime);
        }
    }
}