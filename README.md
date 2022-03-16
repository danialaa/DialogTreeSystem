# Dialog Tree System
A simple dynamic system to build dialogs in a Unity game using an external JSON file  

![](https://user-images.githubusercontent.com/52839918/158600690-e12cd013-9341-4307-9475-fd8ad9bb9a9a.gif)

This system is built with MVC (Models including DialogTree, DialogTreeNode, and DialogOption) design pattern with simple usage for game designers, using JSON to deserialize the dialog text into the tree.  
Users can replay the dialog, but only choose the choices made in the first dialog-run.  
The dialog system also checks if users can get stuck in your dialog (if your dialog has loops) and warns you about it.  
  
## To use the system:

1. Edit the dialog prefab however you like.

![](https://i.gyazo.com/25efd974744aac930d97a967f2ac91e5.png)

You can edit the dialog background image, text fonts, colors, position/size of elements, and button UI.

2. Attach the DialogOpener component to your scene script

![](https://i.gyazo.com/c44ba52aaa20ec07f50a3575a98b5e9c.png)

3. Attach your updated prefab, the name of the speaking NPC, and the name of the JSON file that contains your dialog. *make sure the file is in the Resources folder*
4. Whenever you wish to start the dialog, just call for the DialogOpener.startDialog() function.

# Dialog Tree in JSON

An example of the JSON structure required is attached [here](dialog_example.json). Which contain a list of text nodes along with its options (a max of 3).

# Future work

-To add the ability to structure the dialog via inspector.  
-To increase option numbers (adding left and right buttons to see all options).
