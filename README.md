# Example Angular 2 + ASP.NET Core Application

#### To get up and running...

Step 1. Install Node.js (6 or later). Download from [https://nodejs.org](https://nodejs.org).

Step 2. Install .NET Core. Download from [https://www.microsoft.com/net/core](https://www.microsoft.com/net/core).

Step 3. Clone or download a ZIP of this repository. If you downloaded the ZIP of this repository, extract the ZIP file.

Step 4. Open a terminal, change to the folder where the code was cloned to or extracted to.

Step 5. Run the following commands from the terminal:

```bash
$ npm i

$ npm start
```

The command **npm i** will install all of the Node.js package dependencies, TypeScript type definitions, build the Webpack bundles, and restore the .NET Core NuGet packages. Sometimes this command will fail during execution (there is a lot of network activity, anything can and will go wrong). If it fails, run **npm i** again. The command **npm start** will start the .NET Core web application. The URL of the web server will be displayed in the terminal window.

Step 6. Open a web browser, and navigate to the URL outputted to the console window. The widget application should load. The login form will be pre-filled out. Click 'Login', then use the Widget Tool.

If the web page does not load a working application, delete the **node_modules** folder and run **npm i** again. Yes, this is equivalent to fixing a crashed computer simply by rebooting it. Its not pretty, but usually it works.

This is the initial release of this demo application. It will be further enhanced to support hashed password, user manager, better user experience, etc...