<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Defult.Master" CodeBehind="registrationform.aspx.cs" Inherits="registration.registrationform" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <table>
                <tr>
                <td>Name :</td>
                <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                    </tr>
                <tr>
                    <td>Email:</td>
                    <td><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Password:</td>
                    <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                <td>Blood Group</td>
                <td><asp:RadioButtonList ID="rblbg" runat="server" RepeatColumns="4">
                    <asp:ListItem Text="AB" Value="1"></asp:ListItem>
                    <asp:ListItem Text="A" Value="2"></asp:ListItem>
                    <asp:ListItem Text="B" Value="3"></asp:ListItem>
                    <asp:ListItem Text="O" Value="4"></asp:ListItem>

                    </asp:RadioButtonList></td>
                    </tr>
                <tr>
                <td>Qulification :</td>
                <td><asp:DropDownList ID="ddlqli" runat="server">
                    <%--<asp:ListItem Text="--Select" Value="0"></asp:ListItem>
                     <asp:ListItem Text="BCA" Value="1"></asp:ListItem>
                    <asp:ListItem Text="MCA" Value="2"></asp:ListItem>
                    <asp:ListItem Text="B.Tech" Value="3"></asp:ListItem>--%>
                    </asp:DropDownList></td>
                    </tr>
                <tr>
                <td>Country </td>
                <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true">
                   <%--<asp:ListItem Text="--Select" Value="0"></asp:ListItem>
                     <asp:ListItem Text="India" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Japan" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Russia" Value="3"></asp:ListItem>--%>

                    </asp:DropDownList></td>
                    </tr>
                <tr>
                    <td>State </td>
                    <td><asp:DropDownList ID="ddlstate" runat="server">

                        </asp:DropDownList></td>
                </tr>
                <tr>
                <td></td>
                <td><asp:Button ID="btnsave" runat="server" Text="Register" OnClick="btnsave_Click" /></td>
                    </tr>
                <tr>
                    <td></td>
                    <td><asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>
                        <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" /> </td>

                </tr>
                <tr>
                    <td></td>
                    <td><asp:Label ID="message" runat="server"></asp:Label></td>

                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" OnRowCommand="grid_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Form Id">
                                <ItemTemplate>
                                    <%#Eval("id") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Form Name">
                                <ItemTemplate>
                                    <%#Eval("name") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Blood Group">
                                <ItemTemplate>
                                    <%#Eval("bloodgroup").ToString()=="1"?"AB":Eval("bloodgroup").ToString()=="2"?"A":Eval("bloodgroup").ToString()=="3"?"B":"O" %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Qulification">
                                <ItemTemplate>
                                    <%#Eval("qname") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Country">
                                <ItemTemplate>
                                    <%#Eval("cname") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <%#Eval("sname") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <%#Eval("email") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Password">
                                <ItemTemplate>
                                    <%#Eval("password") %>
                                </ItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="A" CommandArgument='<%#Eval("id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("id") %>' />
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

                        </asp:GridView></td>
                </tr>
            </table>
     </asp:Content>
