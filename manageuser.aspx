<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="manageuser.aspx.cs" Inherits="registration.manageuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <a href="Userform.aspx">Add New User</a>
            </td>
        </tr>
        <tr>
            <td>

                 <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" OnRowCommand="grid_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                     <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="User ID">
                         <ItemTemplate>
                             <%#Eval("uid") %>
                         </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="User Name">
                         <ItemTemplate>
                             <%#Eval("uname") %>
                         </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="User Age">
                         <ItemTemplate>
                             <%#Eval("uage") %>
                         </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="User Hobbies">
                         <ItemTemplate>
                             <%#Eval("uhobbies") %>
                         </ItemTemplate>
                        </asp:TemplateField>

                          <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="A" CommandArgument='<%#Eval("uid") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("uid") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>


                    </Columns>
                     <EditRowStyle BackColor="#2461BF" />
                     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                     <RowStyle BackColor="#EFF3FB" />
                     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                     <SortedAscendingCellStyle BackColor="#F5F7FB" />
                     <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                     <SortedDescendingCellStyle BackColor="#E9EBEF" />
                     <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>

            </td>
        </tr>
    </table>
</asp:Content>
