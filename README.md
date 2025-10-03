# 🚀 Wellz Dialogue System

A simple and efficient **Unity Package Manager (UPM) package** designed to facilitate the creation and management of complex dialogues and conversations in your game projects.

---

## 📦 Installation via Unity Package Manager (UPM)

The recommended way to install the **Wellz Dialogue System** is by using a Git URL within the Unity Package Manager.

### Prerequisites
* You must have **Git** installed on your machine.

### Procedure
1.  Open the **Unity Editor** with your project.
2.  Open the **Package Manager** window (`Window` > `Package Manager`).
3.  Click the **Add** button (`+`) in the upper-left corner.
4.  Select **Add package from git URL...**
5.  Paste the following URL, which points to the package's subfolder within the repository:
https://github.com/WellingtonDePaula/dialogue-system-package.git?path=/com.wellz.dialogue-system
6.  Click **Add**. The Package Manager will clone the repository and import the dialogue system into your project.

---

## 💻 Getting Started and How to Use

### Coming Soon...

---

## ⚠️ Known Issues / Current Status

I am currently working on integrating user-friendly example scenes and prefabs.

### Dialogue UI Prefab Configuration

If you are manually setting up the Dialogue UI Prefab, follow these steps to connect the components:

1.  **Open the DialogueUI Prefab** for editing.
2.  Select the root **DialogueUI** GameObject (or the GameObject where the main UI script is attached).
3.  Ensure the **DialogueUI.cs** script component is attached to this GameObject.
4.  In the Inspector window, drag the following UI elements from the prefab hierarchy into the script's fields:
    * Drag **TxtContent** to the **Dialogue Content** field.
    * Drag **TxtSpeakerName** to the **Speaker Name** field.
    * Drag **ImgSpeakerIcon** to the **Speaker Icon** field.

This ensures your script correctly references the UI elements for runtime display.

### Temporary Sample Access
The Unity Package Manager is **not yet correctly recognizing the dedicated Samples structure**. If you need to access the demonstration assets (scenes, prefabs, etc.) right now, you must import them manually:

1.  Go to the repository on GitHub: https://github.com/WellingtonDePaula/dialogue-system
2.  Navigate to the `Assets` folder.
3.  Manually **copy** the contents of the following folders into your project's main **`Assets`** folder:
    * **`Prefabs`** (for the Dialogue UI prefab).
    * **`Scenes`** and **`Data`** (for the Basic Integration example).
4. Need to do the [Dialogue UI Prefab Configuration](#dialogue-ui-prefab-configuration) and the [Manual Setup (Basic Integration)](#manual-setup-basic-integration)

### Manual Setup (Basic Integration)
If you choose the **Basic Integration** option, the scene assets will require manual configuration after being copied:

1.  Open the copied `SampleScene` and select the **DialogueManager** GameObject.
2.  In the Inspector window for the `DialogueManager` script, drag the following assets to their respective slots:
    * The Dialogue UI prefab.
    * The Canvas GameObject from the scene.
    * The Game Events located in `Data/Events/Dialogues/Inputs`, they have very intuitive names.
3.  Select the **InputManager** GameObject in the scene.
4.  In the Inspector window for the `PlayerInputReader` script, drag the **same input events** that you used for the DialogueManager to their respective slots.

I expect to resolve the UPM Samples recognition issue in the next update to enable direct one-click import.

---

## 📄 License

This project is distributed under the **MIT License**. You are free to use, modify, and distribute this package in your personal and commercial projects.

---

## 👨‍💻 Contact and Support

Developed by **Wellington De Paula**.

If you have questions, suggestions, or find bugs, please open an **Issue** in this GitHub repository.