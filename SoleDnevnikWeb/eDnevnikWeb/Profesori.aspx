<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesori.aspx.cs" Inherits="eDnevnikWeb.Profesori" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Profesorska strana"></asp:Label>
    
    </div>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="NazivPredmeta" DataValueField="NazivPredmeta">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eDnevnikConnectionString2 %>" SelectCommand="SELECT DISTINCT [NazivPredmeta] FROM [Predmeti]"></asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="GodinaSkolovanja" DataValueField="GodinaSkolovanja">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:eDnevnikConnectionString %>" SelectCommand="SELECT DISTINCT [GodinaSkolovanja] FROM [Godine]"></asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3" DataTextField="BrojOdeljenja" DataValueField="BrojOdeljenja">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:eDnevnikConnectionString %>" SelectCommand="SELECT DISTINCT [BrojOdeljenja] FROM [Odeljenja]"></asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource4" DataTextField="SkolskaGodina" DataValueField="SkolskaGodina">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:eDnevnikConnectionString %>" SelectCommand="SELECT DISTINCT [SkolskaGodina] FROM [Godine]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
