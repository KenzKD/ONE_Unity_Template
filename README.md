# ONE_Unity_Template

### Game Guidelines

1) Make sure to **Install the WebGL Build Support** and Use the Latest Version of Unity **2022.3 LTS**

  <p align="center">
    <img src="https://github.com/KenzKD/ONE_Unity_Template/assets/65004578/714cefa6-60c9-4e4c-8c8d-74b93c72313d" width="100%" />
  </p>

2) It is **Recommended to Download the Zip** of this Template instead of the Release Packages.

3) As the game has to work on many different devices. You should be able to play most of the game using just **1 Finger**. Try not to use the keyboard, unless you need to input text (I believe when you need to type something on a smartphone, the keyboard will automatically appear).

4) The Build Size should be **Less than or Equal to 20 MB**. Make sure to **Compress** textures, meshes, Audio, etc. The Installed **"WebGL Optimizer"** Plugin can help with this.(The Build Size of an empty Project is 11.2 MB currently)

   Here are some things you can look up to learn more about making Build Size smaller and using the “WebGL Optimizer” tool:
   
   - **_https://docs.crazygames.com/sdk/unity/resources/export-tips/_**
   
   - **_https://github.com/CrazyGamesCom/unity-optimizations-package_**
   
5) This template already has all of the appropriate Build settings to get the Smallest File Size enabled. If you are only using the All_In_One_Manager Unity Package. Then you will have to look into Re-applying the settings on your own version.

6) Do your **Testing on Google Chrome**. That is our Recommended Platform. 
   <br><br>Here is how to Run your Built WebGL Games: **_https://youtu.be/Ceqbmm7ydS8?si=J2Yd9te7_tfUI36_**

7) **Don’t** change the camera’s position or angle directly. If you want to move or rotate the camera, do it by changing the **“Camera Container”**. This applies to any scripts that move the camera too. We do this because we use the MilkShake Plugin to handle any the camera shakes and changing its position can mess with the animation.
   
<p align="center">
  <img src="https://github.com/KenzKD/ONE_Unity_Template/assets/65004578/c55de439-f4d6-4a5e-9799-2f66b46c68fd" width="50%" />
</p>

8) **Avoid using `void Awake()`**. Using `void Awake()` can cause issues in the Browser, as it may sometimes fail to execute the functions within it. Instead, **use `void Start()`.**

9) Make sure to **Normalize Any New Audio** before Exporting the Game to ensure consistent Audio Volume. I use a tool called Davinci Resolve to do this, but there might be other tools you can use too.
   <br><br>Here is a video about the process: **_https://youtu.be/nZJkcca7vJ4?si=uO_QnZoWxXGuMTnk_**

10) Learn how to use the **[DoTween](https://dotween.demigiant.com/index.php)** Plugin. It allows you to easily add Animations to your Game.<br>
    Here is a **[Cheat Sheet](https://easings.net/)** for the different Animation Easing Settings.

11) Learn how to use **Virtual Desktops** for your OS. This can help you Organize your work better and can even make following tutorials much easier.
    <br><br>Here is a Setup Video for Windows 11: **_https://youtu.be/uRuQVtlV81s?si=aQ-c0X4TaaLB5aGC_**
    <br><br>You can setup your Touchpad like this to make it easier to switch between Desktops:

    <p align="center">
      <img src="https://github.com/KenzKD/ONE_Unity_Template/assets/65004578/746d105b-d15d-4d39-9353-3ec69b0a811c" width="75%" />
    </p>
<br><br>

- - - -
# Frequently Used Functions

**Basic Syntax to Call a Function from a Manager Script**

```
ManagerScriptName.Instance.FunctionName(Parameters)
```

1) **[AudioManager](https://github.com/KenzKD/ONE_Unity_Template/blob/main/Assets/Scripts/Manager%20Scripts/AudioManager.cs)**
    
    - `PlaySFX(String AudioClipName)` -> Plays a Sound Effect using the AudioClipName
    - `SetSFXAllowOverlap(bool allowOverlap)` -> A bool variable to Allow SFX to Overlap one Another. By default it is set to false.
    - `SetSFXLooping(bool isLooping)` -> A bool variable to Toggle looping of sfxSource. By default it is set to false.
    - `StopSFX()` -> Stops All SFX Instantly including Looping Audio
      
2) **[ScoreManager](https://github.com/KenzKD/ONE_Unity_Template/blob/main/Assets/Scripts/Manager%20Scripts/ScoreManager.cs)**
    
    - `AddPoint(float Points)` -> Add Points to the Score, if it reaches the total Score it runs the Win Function
    - `Wrong(Vector3 Position)`  -> Displays 'Wrong' at the given position and does a little Animation. 
  
3) **[SettingsManager](https://github.com/KenzKD/ONE_Unity_Template/blob/main/Assets/Scripts/Manager%20Scripts/SettingsManager.cs)**
    
    - `AllowGamePlay()` -> Returns true if the game is Started, not Paused, and the Mouse Pointer is not over a UI object.

- - - -

### If you have any Ideas or Suggestions, Create a Pull Request for me to Review.


