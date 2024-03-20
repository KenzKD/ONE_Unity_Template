# ONE_Unity_Template

### Game Limitations

1) Make sure to Install the WebGL Build Support and Use the latest Unity 2022.3 LTS

<p align="center">
  <img src="https://github.com/KenzKD/ONE_Unity_Template/assets/65004578/714cefa6-60c9-4e4c-8c8d-74b93c72313d" width="100%" />
</p>

2) As the game has work on many different devices. You should be able to play most of the game using just one mouse pointer. Try not to use the keyboard, unless you need to input text (I believe when you need to type something on a smartphone, the keyboard will automatically appear).

3) The Build Size should be less than or Equal to 20 MB. Make sure to compress textures, meshes, Audio, etc. The Installed "WebGL Optimizer" Plugin can help with this.(The Build Size of an empty Project is 11.2 MB currently)

   Here are some things you can look up to learn more about making Build Size smaller and using the “WebGL Optimizer” tool:
   
   https://docs.crazygames.com/sdk/unity/resources/export-tips/
   
   https://github.com/CrazyGamesCom/unity-optimizations-package
   
4) This template already has all of the appropriate Build settings to get the Smallest File Size enabled. If you are only using the All_In_One_Manager Unity Package. Then you will have to look into applying these settings on your own version.

5) Do your Testing on Google Chrome. That is our Recommended Platform.

6) Don’t change the camera’s position or angle directly. If you want to move or rotate the camera, do it by changing the “Camera Container”. This rule is for any scripts that move the camera too. We do this because we use the MilkShake tool to make the camera shake.
   
<p align="center">
  <img src="https://github.com/KenzKD/ONE_Unity_Template/assets/65004578/c55de439-f4d6-4a5e-9799-2f66b46c68fd" width="50%" />
</p>


7) Make sure to Normalize the Audio for before Exporting the Game to ensure consistent Audio Volume. I use a tool called Davinci Resolve to do this, but there might be other tools you can use too.

   Here is a video about the process: https://youtu.be/nZJkcca7vJ4?si=uO_QnZoWxXGuMTnk


### If you have any Ideas or Suggestions, Create a Pull Request for me to Review.

