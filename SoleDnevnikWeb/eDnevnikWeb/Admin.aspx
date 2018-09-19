<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="eDnevnikWeb.eDnevnik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfProfesorID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Ime profesora"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtImeProfesora" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Kontakt telefon"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKontaktTelefon" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Login sifra"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLoginSifra" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Naziv predmeta"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddPredmeti" runat="server" DataSourceID="SqlDataSource1" DataTextField="NazivPredmeta" DataValueField="NazivPredmeta">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eDnevnikConnectionString %>" SelectCommand="IzborPredmeta" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Broj odeljenja"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBrojOdeljenja" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Godina skolovanja"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGodinaSkolovanja" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Skolska godina"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSkolskaGodina" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblSuccessMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvProfesori" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True" Width="857px"  >
                <Columns>
                    <asp:BoundField DataField="ImeProfesora" HeaderText="Ime Profesora" SortExpression="ImeProfesora" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="KontaktTelefon" HeaderText="Kontakt Telefon" SortExpression="KontaktTelefon" />
                    <asp:BoundField DataField="LoginSifra" HeaderText="Login Sifra" SortExpression="LoginSifra" />
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("profesorID") %>' OnClick="lnk_OnClick">View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:eDnevnikConnectionString %>" SelectCommand="SELECT [ImeProfesora], [Email], [KontaktTelefon], [LoginSifra] FROM [Profesori]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
