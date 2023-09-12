# Unity Lerper
 ---
  Scripts that are intended to make lerping a much easier and organized experience.

---
#### Included Scripts
The main folder includes the following scripts:
- Stage
  - this is the step of every animation, that consists of the classes from the Lerpers folder.
- StageManager
  - this handles a list of stages, the current Stage and has various methods for managing the animation steps.
- **ObjectToBeLerped**
  - this is the script that is attached to the object you want to lerp, which has a StageManager object added to it.




The Lerpers folder includes the following C# classes:
- **Lerper**
- ColorLerper
- QuaternionLerper
- Vector3Lerper

>Every class from the Lerpers folder inherits from the Lerper class.
>Each Lerper is for the specified property, and has the following variables changeable:
> - willLerp
> - inheritLast
> - speed
> - delay
> - curve
> - init
> - final

---
#### How to use
The way it works is: 
1. you attach the *ObjectToBeLerped* to the GameObject you want to animate
2. then add how many stages you want and configure them to your liking
3. then you just need a script to activate the *StartLerping* method of the *ObjectToBeLerped* and then the animation will start!