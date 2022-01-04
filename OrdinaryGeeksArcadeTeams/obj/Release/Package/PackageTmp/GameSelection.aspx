<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="GameSelection.aspx.cs" Inherits="OrdinaryGeeksArcadeTeams.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <p><asp:Label ID="HeaderLabel" runat="server" /></p>
            <p><asp:Label ID="WelcomeLabel" runat="server" Text=""></asp:Label></p>
            
            <p><asp:Label ID="TokenLabel" runat="server" Text=""></asp:Label></p>
            <p>Do you want to spend 1 to play Planetary Organization Defender?</p>
          <asp:Button ID="Planetary" runat="server" Text="Planetary Organization Defender 1 Token" OnClick="Planetary_Click" />
            <asp:Label ID="PlanetarySuccess" runat="server" Text="" ></asp:Label>
    </form>
  
</body>
</html>
