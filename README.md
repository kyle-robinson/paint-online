# Paint Online

[![MSBuild-Debug](https://github.com/kyle-robinson/paint-online/actions/workflows/msbuild-debug.yml/badge.svg)](https://github.com/kyle-robinson/paint-online/actions/workflows/msbuild-debug.yml)
&nbsp;
[![MSBuild-Release](https://github.com/kyle-robinson/paint-online/actions/workflows/msbuild-release.yml/badge.svg)](https://github.com/kyle-robinson/paint-online/actions/workflows/msbuild-release.yml)
&nbsp;
[![CodeQL](https://github.com/kyle-robinson/paint-online/actions/workflows/codeql.yml/badge.svg)](https://github.com/kyle-robinson/paint-online/actions/workflows/codeql.yml)

A multithreaded online version of "Paint" that utilises a client-server architecture to allow for connected users to paint collectively on a single canvas.

*- Click <a href="https://kyle-robinson.github.io/html/networking" target="_blank">here</a> to view project on website -*

<img src="Assets/Paint Demo.png" alt="Paint Application Demo 1" border="10" />

## List of Features

- [x] Client List
- [x] Canvas Painting
- [x] Canvas Clearing
- [x] Username System
- [x] Brush Colours
- [x] Admin System
- [x] Spawning of Clients

## Getting Started

Refer to the following information on how to install and use the application.

### Dependencies
To use the application, the following prerequisites must be met.
* Windows 10+
* Visual Studio
* Git Version Control

The application does not rely on the any additional libraries or APIs to function.

### Installing

To download a copy of the application, select "Download ZIP" from the main code repository page, or create a fork of the project. More information on forking a GitHub respository can be found [here](https://www.youtube.com/watch?v=XTolZqmZq6s).

### Executing program

A runtime configuration has been setup to run an instance of both the server and client project on project load. To create additional instances of the client application, follow these steps while the application in running.
1. Navigate to the Client project in the Solution Explorer.
2. Right-click the project and navigate to the Debug option.
3. Click "Start New Instance" to generate another Client application.

---

### Credits

        Code Reference
            https://youtu.be/EA5jF_7FteM

        Design Reference
            https://youtu.be/xyEG1e5Gnic
