<%@ Page Language="C#"  Title="Planetary Organization Defender" AutoEventWireup="true" CodeBehind="PlanetaryOrganizationDefender.aspx.cs" Inherits="OrdinaryGeeksArcadeTeams.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link rel="shortcut icon" href="~/Content/TemplateData/favicon.ico"/>
    <link rel="stylesheet" href="~/Content/TemplateData/style.css"/>
    
</head>
<body  >
 
    <div id="unity-container" class="unity-desktop">
        <canvas id="unity-canvas"></canvas>
        <div id="unity-loading-bar">
            <div id="unity-logo"></div>
            <div id="unity-progress-bar-empty">
                <div id="unity-progress-bar-full"></div>
            </div>
        </div>
        <div id="unity-footer">
            <div id="unity-webgl-logo"></div>
            <div id="unity-fullscreen-button">Click Here For Full Screen</div>
            <div id="unity-build-title">Starlight Rendered Horizon</div>
        </div>
    </div>

        <script>
            //If you put a / in front of it it will go to www.ordinarygeeks.com/ordinarygeeksarcadestore/ordinarygeeksarcadestore/content/build/ssrh2021webgl.loader.js
            var buildUrl = "Content/Build";
            var loaderUrl = buildUrl + "/SSRH2021WEBGL.loader.js";
        var config = {
                dataUrl: buildUrl + "/SSRH2021WEBGL.data",
            frameworkUrl: buildUrl + "/SSRH2021WEBGL.framework.js",
            codeUrl: buildUrl + "/SSRH2021WEBGL.wasm",
            streamingAssetsUrl: "StreamingAssets",
            companyName: "Ordinary Geeks LLC",
            productName: "Ordinary Geeks Arcade",
            productVersion: "0.1",
        };

        var container = document.querySelector("#unity-container");
        var canvas = document.querySelector("#unity-canvas");
        var loadingBar = document.querySelector("#unity-loading-bar");
        var progressBarFull = document.querySelector("#unity-progress-bar-full");
        var fullscreenButton = document.querySelector("#unity-fullscreen-button");

        if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
                container.className = "unity-mobile";
            config.devicePixelRatio = 1;
        } else {
            canvas.style.width = "1360px";
            canvas.style.height = "768px";
        }
        loadingBar.style.display = "block";

        var script = document.createElement("script");
        script.src = loaderUrl;
            script.onload = () => {
              
                createUnityInstance(canvas, config, (progress) => {
                    progressBarFull.style.width = 100 * progress + "%";
                }).then((unityInstance) => {
                    loadingBar.style.display = "none";
                  //  unityInstance.SetFullscreen(1);
                    fullscreenButton.onclick = () => {
                        unityInstance.SetFullscreen(1);
                    };

                  //  fullscreenButton.click();
                }).catch((message) => {
                    alert(message);
                });
        };
        document.body.appendChild(script);</script>
    </body>

</html>
