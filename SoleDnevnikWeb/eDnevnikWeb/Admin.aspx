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
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="#009933"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="#CC0000"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvProfesori" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Width="857px" ForeColor="#333333"  >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                <asp:BoundField DataField="ImeProfesora" HeaderText="Име професора" />
                <asp:BoundField DataField="Email" HeaderText="Мејл" />
                <asp:BoundField DataField="KontaktTelefon" HeaderText="Контакт телефон" />
                <asp:BoundField DataField="LoginSifra" HeaderText="Логин шифра" />
                <asp:BoundField DataField="NazivPredmeta" HeaderText="Naziv predmeta" />
                <asp:BoundField DataField="BrojOdeljenja" HeaderText="Broj Odeljenja" />
                <asp:BoundField DataField="GodinaSkolovanja" HeaderText="Godina Skolovanja" />
                <asp:BoundField DataField="SkolskaGodina" HeaderText="Skolska Godina" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("ProfesorID") %>' OnClick="lnk_OnClick">View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
