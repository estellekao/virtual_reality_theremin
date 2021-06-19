[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/estellekao/virtual_reality_theremin">
  </a>

  <h3 align="center">Virtual Reality Theremin</h3>

  <p align="center">
    Virtual theremin with pitch guide assistance for novice learners. Developed on a View-Master VR headset with Leap Motion controller for hand tracking.
    <br />
    <a href="https://github.com/estellekao/virtual_reality_theremin/Project_Demo.mp4">View Demo</a>
    ·
    <a href="https://github.com/estellekao/virtual_reality_theremin/Project_Final_Report.pdf">View Report</a>
  </p>
</p>

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#hardware">Hardware</a></li>
        <li><a href="#software">Software</a></li>
        <li><a href="#collaterals">Collaterals</a></li>
      </ul>
    </li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project
Theremin is a proximity sensor based musical instrument
that requires rigorous training to master. Beginners
may struggle in playing the correct tune because of the lack of
physical contact to the instrument. This project creates a virtual theremin with pitch guides designed for beginner training.

### Hardware

If you would like to just play the theremin without the Virtual Reality (VR) experience, you just need:
* [Leap Motion Controller](https://www.ultraleap.com/product/leap-motion-controller/#pricingandlicensing)

To add VR capability, you will need:
* [View-Master Deluxe VR Viewer](https://www.walmart.com/ip/View-Master-Deluxe-Vr-Viewer/54297042)
* [Topfoison 6'' 1080p LCD](https://www.topfoison.com/1080p%20hdmi-mipi%20display.html)
* [InvenSense MPU-9250](https://www.amazon.com/s?k=mpu-9250&ref=nb_sb_noss_1)
* [Arduino Teensy 3.2](https://www.pjrc.com/teensy/teensy31.html)
* [2x USB Cables](https://www.amazon.com/s?k=usb+cable&ref=nb_sb_noss)
* [1x HDMI-to-mini HDMI Cable](https://www.amazon.com/s?k=hdmi+to+mini+hdm)

### Software

* The View-Master Cardboard plugin requires us to use the the older version of Unity, [Unity LTS Release 2018.4.20f1](https://unity3d.com/unity/qa/lts-releases?version=2018.4&page=2)

* Leap Motion Setup, [Leap Motion Developer SDK](https://developer.leapmotion.com/#101)

Further readings on [Unity and Leap Motion Controller setup](https://libguides.gatech.edu/c.php?g=731374&p=6240622)

### Collaterals

##### Script:
| Filename      | Purpose |
| ----------- | ----------- |
| Assets/AudioManager.cs | controls the playback speed (=pitch) of the audio file|
| Assets/Sound.cs   | contains sound class properties|
| Assets/GetLeapFinger.cs | controls Right and Left hand (pitch and volume)|
| Assets/move_card.cs | moves the orange quad that acts as the pitch guide|

##### Scene:
| Filename      | Purpose |
| ----------- | ----------- |
| Assets/Scenes/Scene_01 | scene for the theremin game environment |

##### Material and Coloring:
| Filename      | Purpose |
| ----------- | ----------- |
| Assets/Materials | Theremin coloring |
| Assets/Resources/Materials | auditorium 3D background and pitch guide quads |

##### Sound File:
| Filename      | Purpose |
| ----------- | ----------- |
| Assets/Resources/Sounds | one sound file total. use scripts to control playback speed to alter pitch. |

##### Leap Motion Controller Plugin:
| Filename      | Purpose |
| ----------- | ----------- |
| Assets/Plugins/LeapMotion | contains the Core and Interactive modules necessary for finger tracking |



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/othneildrew/Best-README-Template.svg?style=for-the-badge
[contributors-url]: https://github.com/estellekao/
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/estellekao
