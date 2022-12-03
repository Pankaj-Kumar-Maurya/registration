<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="employee.aspx.cs" Inherits="registration.employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <table>
                <tr>
                <td>Name :</td>
                <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                    </tr>
                <tr>
                <td>Gender :</td>
                <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                    </asp:RadioButtonList></td>
                    </tr>
               <tr>
                   <td> Image:</td>
                   <td><asp:FileUpload ID="fuimage" runat="server" /> </td>
               </tr>
              
                <tr>
                <td></td>
                <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"/></td>
                    </tr>
               
                <tr>
                    <td></td>
                    <td><asp:Label ID="message" runat="server"></asp:Label></td>

                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="employeegrid" runat="server" AutoGenerateColumns="false" OnRowCommand="employeegrid_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Employee Id">
                                <ItemTemplate>
                                    <%#Eval("eid") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Employee Name">
                                <ItemTemplate>
                                    <%#Eval("ename") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Employee Gender">
                                <ItemTemplate>
                                    <%#Eval("egender").ToString()=="1"?"Male":Eval("egender").ToString()=="2"?"Female":"Other" %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Employee  Image">
                                <ItemTemplate>
                                   <asp:Image ID="img1" runat="server" Height="60px" Width="60px" ImageUrl='<%#Eval("eimage","~/EMPLOYEEPICS/{0}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="A" CommandArgument='<%#Eval("eid") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                     <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="B" CommandArgument='<%#Eval("eid")+","+ Eval("eimage")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                        </Columns>

                        </asp:GridView></td>
                </tr>
            </table>

</asp:Content>
