<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryItPageLocal.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {}
        .auto-style2 {
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>Wind Intensity Service: A service that takes a longitude and latitude and returns the average wind speed using both 10m wind rose data and 50m wind rose data from the past 30 years</strong></div>
        <p>
            <asp:Label ID="WindURL" runat="server"></asp:Label>
        </p>
        <p style="width: 1517px">
            <strong>Operation</strong>: AvgWindIntensity <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Input</strong>: decimal latitude, decimal longitude&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Output</strong>: decimal windspeed</p>
        <asp:TextBox ID="WindLongitude" runat="server"></asp:TextBox>
        <asp:TextBox ID="WindLatitude" runat="server"></asp:TextBox>
        <p>
        <asp:Button ID="WindTryIt" runat="server" OnClick="WindTryIt_Click" Text="TryIt" />
        </p>
        <p>
            <asp:Label ID="WindOutput" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <strong>News Service: A service that takes a list of topics and returns as many news article websites as possible about those topics</strong></p>
        <p>
            <asp:Label ID="NewsURL" runat="server"></asp:Label>
        </p>
        <p style="font-weight: 700">
            Operation<span class="auto-style1"><span class="auto-style2">: GetNews </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Input<span class="auto-style2">: string[] topics&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Output</strong>: string[] urls</span></span></p>
        <p>
            <strong>Note</strong>: Type in topics in a comma separated list, ex: ASU,football will return articles about ASU football</p>
        <asp:TextBox ID="NewsInput" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="NewsButton" runat="server" OnClick="NewsButton_Click" Text="TryIt" />
        </p>
        <asp:Label ID="NewsOutput" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <strong>Bank Service (Withdraw)</strong>: Withdraw money from the bank account linked to the card<p>
            <asp:Label ID="BankWURL" runat="server"></asp:Label>
        </p>
        <p>
            <strong>Operation: </strong>Withdraw&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Input:</strong> string encryptedcc, double amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Output:</strong> bool result</p>
        <p style="width: 1224px">
            <strong>Note about encryptedcc</strong>: The cards used are not encrypted yet because a separate group member is working on encryption/decryption. When we start using this service in the application we are making, the string encryptedcc will actually be encrypted and I will add a line of code to call my group member&#39;s service to decrypt it.&nbsp;
        </p>
        <p style="width: 1226px">
            <strong>Note about the available accounts</strong>: Because of the nature of the project we want to do, there was no area that would make sense to have the user register for a bank account. As a result, I simply made a txt file with accounts that are made up of valid card numbers and balances. The valid card numbers are <strong>4024007128367546</strong>, <strong>4532813979077604</strong>, <strong>4539672704320819</strong>, and <strong>4532335888466231</strong> for now. Withdrawing from a card will reduce its balance in the txt file. If the card number is invalid, or there is not enough balance, false will be returned.</p>
        <asp:TextBox ID="BankWInput1" runat="server"></asp:TextBox>
        <asp:TextBox ID="BankWInput2" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="BankWButton" runat="server" OnClick="BankWButton_Click" Text="TryIt" />
        </p>
        <p>
            <asp:Label ID="BankWOutput" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <strong>Bank Service (Deposit)</strong>: Deposit money from the bank account linked to the card<p>
            <asp:Label ID="BankDURL" runat="server"></asp:Label>
        </p>
        <p>
            <strong>Operation: </strong>Deposit&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Input:</strong> string encryptedcc, double amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Output:</strong> bool result</p>
        <p style="width: 1244px">
            <strong>Note about encryptedcc</strong>: The cards used are not encrypted yet because a separate group member is working on encryption/decryption. When we start using this service in the application we are making, the string encryptedcc will actually be encrypted and I will add one line of code to call my group member&#39;s service to decrypt it.&nbsp;
        </p>
        <p style="width: 1245px">
            <strong>Note about the available accounts</strong>: Because of the nature of the project we want to do, there was no area that would make sense to have the user register for a bank account. As a result, I simply made a txt file with accounts that are made up of valid card numbers and balances. The valid card numbers are <strong>4024007128367546</strong>, <strong>4532813979077604</strong>, <strong>4539672704320819</strong>, and <strong>4532335888466231</strong> for now. Depositing to a card will increase its balance in the txt file. If the card number is invalid, false will be returned.</p>
        <asp:TextBox ID="BankDInput1" runat="server"></asp:TextBox>
        <asp:TextBox ID="BankDInput2" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="BankDButton" runat="server" OnClick="BankDButton_Click" Text="TryIt" />
        </p>
        <p>
            <asp:Label ID="BankDOutput" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p style="width: 1095px">
            <strong>Subscription Service (GetSubs)</strong>: Returns the list of subscriptions for the username if they exist in the txt file.</p>
        <asp:Label ID="SubGURL" runat="server"></asp:Label>
        <p>
            <strong>Operation</strong>: GetSubs&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Input</strong>: string username&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Output</strong>: string[] list</p>
        <p>
            <asp:TextBox ID="SubGInput" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="SubGButton" runat="server" OnClick="SubGButton_Click" Text="TryIt" />
        </p>
        <p>
            <asp:Label ID="SubGOutput" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p style="width: 1257px">
            <strong>Subscription Service (AddSub)</strong>: Adds a subscription to the username specified. If the username does not exist, it creates the user in the txt and adds the subscription to them.</p>
        <asp:Label ID="SubAURL" runat="server"></asp:Label>
        <p>
            <strong>Operation</strong>: AddSub&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Input</strong>: string username, string sub&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Output</strong>: bool result</p>
        <asp:TextBox ID="SubAInput1" runat="server"></asp:TextBox>
        <asp:TextBox ID="SubAInput2" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="SubAButton" runat="server" OnClick="SubAButton_Click" Text="TryIt" />
        </p>
        <asp:Label ID="SubAOutput" runat="server"></asp:Label>
        <br />
        <p style="width: 1261px">
            <strong>Subscription</strong> <strong>Service</strong> <strong>(RemoveSub)</strong>: Removes a subscription from the username specified. If this was thhe last service the username was subscribed to, the username also gets removed from the txt file.</p>
        <asp:Label ID="SubRURL" runat="server"></asp:Label>
        <p>
            <strong>Operation</strong>: RemoveSub&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Input</strong>: string username, string sub&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Output</strong>: bool result</p>
        <asp:TextBox ID="SubRInput1" runat="server"></asp:TextBox>
        <asp:TextBox ID="SubRInput2" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="SubRButton" runat="server" OnClick="SubRButton_Click" Text="TryIt" />
        </p>
        <asp:Label ID="SubROutput" runat="server"></asp:Label>
        <p>
            &nbsp;</p>
        <p>
            <strong>Catalog Service (ItemsInCategory)</strong>: Returns the list of services in the category specified in a comma separated string (RESTful service)</p>
        <asp:Label ID="CatItemsURL" runat="server"></asp:Label>
        <p>
            <strong>Operation</strong>: ItemsInCategory&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Input</strong>: string category&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Output</strong>: string categoryitems</p>
        <p>
            Note: The categories available can be retrieved by calling the CatalogTypes service below.</p>
        <asp:TextBox ID="CatItemsInput" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="CatItemsButton" runat="server" OnClick="CatItemsButton_Click" Text="TryIt" />
        </p>
        <asp:Label ID="CatItemsOutput" runat="server"></asp:Label>
        <p>
            &nbsp;</p>
        <p>
            <strong>Catalog Service (CatalogTypes)</strong>: Returns a list of categories we have services for&nbsp; in a comma separated string (RESTful service)</p>
        <asp:Label ID="CatTypesURL" runat="server"></asp:Label>
        <p>
            <strong>Operation</strong>: CatalogTypes&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Input</strong>: None&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Output</strong>: string catalogTypes</p>
        <asp:Button ID="CatTypesButton" runat="server" OnClick="CatTypesButton_Click" Text="TryIt" />
        <br />
        <br />
        <asp:Label ID="CatTypesOutput" runat="server"></asp:Label>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
