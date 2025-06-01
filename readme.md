A simple C# program (Windows Forms) that implements classical celestial mechanics using Jupiter and the Galilean moons (Io, Europa, Ganymede and Callisto) as examples. The program uses the Euler method to calculate velocity vectors and positions of the objects based on classes and methods of the vector algebra library `Vector.cs` and the particle library `Particle.cs`.

The standard problem of celestial mechanics was solved at a higher level of abstraction with the help of the object-oriented approach. Implemented solution is not applicable to serious scientific calculations due to the low performance of the algorithm, but it is simple and understandable for students when learning celestial mechanics, since the operations are performed on particles that have the properties of real objects.

You can download the executable file `Celestial.exe` on the [release page](https://github.com/ap13ski/Celestial-Mechanics/releases/tag/v.1.0). 

You may need to [install](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net461) `.NET Framework 4.6.1` to run the program as well ([mirror](https://github.com/ap13ski/Protractor/releases/download/v1.0/default.NET_Runtime_Pack_Offline_Installer_NDP461-KB3102436-x86-x64-AllOS-ENU.exe)).

Compiled with Visual Studio 2015 Community, .NET Framework 4.6.1.

![Screenshot](celestial.png)

Short demonstration video is available (1 min, 1.5 Mb):

https://github.com/user-attachments/assets/09499bcf-33fd-459d-a0ff-632ca05ee21b
