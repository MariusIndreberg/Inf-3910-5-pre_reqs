# Inf-3910-5-pre_reqs

A step-by-step guide to install all frameworks, libraries etc needed for the inf-3910-5 course.
Guide is made under the assumption that the VS Code editor is used.


1. Install Stuff!

    1. Ubuntu 18.04
        1. Install [Mono](https://www.mono-project.com/download/stable/) 
        2. Install [Dotnet Core 3.0 SDK](https://dotnet.microsoft.com/download)
        3. Install FAKE as global tool. (Type `dotnet tool install fake-cli -g` in your terminal)
        4. Install Paket as global tool. (type `dotnet tool install paket -g` in your terminal)
        5. Install [Node.js (>= 8.0)](https://github.com/nodesource/distributions/blob/master/README.md)
        6. Install [Yarn (>= 1.10.1)](https://yarnpkg.com/lang/en/docs/install/#debian-stable) 
        7. Install the Ionide extension in Visual Studio Code


    2. MacOs 
        1. Install [Mono](https://www.mono-project.com/download/stable/) 
        2. Install [Dotnet Core 3.0 SDK](https://dotnet.microsoft.com/download)
        3. Install FAKE as global tool. (Type `dotnet tool install fake-cli -g` in your terminal)
        4. Install Paket as global tool. (type `dotnet tool install paket -g` in your terminal)
        5. Install  [Node.js (>= 8.0)](https://nodejs.org/en/download/)
        6. Install  [Yarn (>= 1.10.1)](https://yarnpkg.com/lang/en/docs/install/#mac-stable) 
        7. Install the Ionide extension in Visual Studio Code
    3. Windows 
        1. Install [Dotnet Core 3.0 SDK](https://dotnet.microsoft.com/download)
        2. Install FAKE as global tool. (Type `dotnet tool install fake-cli -g` in your terminal)
        3. Install Paket as global tool. (type `dotnet tool install paket -g` in your terminal)
        4. Install  [Node.js (>= 8.0)](https://nodejs.org/en/download/)
        5. Install  [Yarn (>= 1.10.1)](https://yarnpkg.com/lang/en/docs/install/#mac-stable) 
        6. Install the Ionide extension in Visual Studio Code



2. Test if it works.
    1. Write `dotnet new -i SAFE.Template` to install dotnet SAFE template.
    2. Write `dotnet new SAFE --s giraffe` to create a new SAFE project.
    3. Write `fake build -t run` to test default SAFE App.