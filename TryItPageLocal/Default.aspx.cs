using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Web.UI;


namespace TryItPageLocal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected ServiceReference1.Service1Client serviceList = new ServiceReference1.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            WindURL.Text = serviceList.Endpoint.Address.ToString();
            NewsURL.Text = serviceList.Endpoint.Address.ToString();
            BankWURL.Text = serviceList.Endpoint.Address.ToString();
            BankDURL.Text = serviceList.Endpoint.Address.ToString();
            SubGURL.Text = serviceList.Endpoint.Address.ToString();
            SubAURL.Text = serviceList.Endpoint.Address.ToString();
            SubRURL.Text = serviceList.Endpoint.Address.ToString();
            CatTypesURL.Text = "http://localhost:60473/Service1.svc";
            CatItemsURL.Text = "http://localhost:60473/Service1.svc/";
        }

        protected void WindTryIt_Click(object sender, EventArgs e)
        {
            try
            {
                decimal latitude = decimal.Parse(WindLatitude.Text);
                decimal longitude = decimal.Parse(WindLongitude.Text);
                bool invalid = false;

                if (latitude > 90 || latitude < -90)
                {
                    WindOutput.Text = "Invalid Latitude, needs to be between -90 and 90 degrees inclusive";
                    invalid = true;
                }
                if (longitude > 180 || longitude < -180)
                {
                    if (invalid == true)
                        WindOutput.Text = "Invalid Latitude, needs to be between -90 and 90 degrees inclusive<br />Invalid Longitude, needs to be between -180 and 180 degrees inclusive";
                    else
                        WindOutput.Text = "Invalid Longitude, needs to be between -180 and 180 degrees inclusive";
                    invalid = true;
                }

                if (!invalid)
                    CallWindService(latitude, longitude);
            }
            catch
            {
                WindOutput.Text = "Invalid Input!";
            }
        }

        // calls the wind service
        private void CallWindService(decimal latitude, decimal longitude)
        {
            try
            {
                decimal speed = serviceList.AvgWindIntensity(longitude, latitude);
                WindOutput.Text = "Average wind speed: " + speed.ToString() + "m/s";
            }
            catch
            {
                WindOutput.Text = "Error calling wind service!";
            }
        }

        // on news button click
        protected void NewsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string input = NewsInput.Text;
                if (input.Length == 0)
                {
                    NewsOutput.Text = "Please put at least one topic in the input box";
                    return;
                }
                string[] inputList = input.Split(',');
                CallNewsService(inputList);
            }
            catch
            {
                NewsOutput.Text = "Invalid Input!";
            }
        }

        // calls the news service
        private void CallNewsService(string[] list)
        {
            try
            {
                string[] response = serviceList.GetNews(list);
                string output = "";
                for (int i = 0; i < response.Length; i++)
                {
                    output += response[i] + "<br/>";
                }
                output = output.Substring(0, output.Length - 5);
                NewsOutput.Text = output;
            }
            catch
            {
                NewsOutput.Text = "Error calling news service!";
            }
        }

        // button for bank withdraw
        protected void BankWButton_Click(object sender, EventArgs e)
        {
            try
            {
                string cc = BankWInput1.Text;
                double amount = double.Parse(BankWInput2.Text);
                bool result = serviceList.BankWithdraw(cc, amount);
                if (result)
                    BankWOutput.Text = "True";
                else
                    BankWOutput.Text = "False";
            }
            catch
            {
                BankWOutput.Text = "Invalid Input, most likely an invalid amount entered";
            }
        }

        // button for bank deposit 
        protected void BankDButton_Click(object sender, EventArgs e)
        {
            try
            {
                string cc = BankDInput1.Text;
                double amount = double.Parse(BankDInput2.Text);
                bool result = serviceList.BankDeposit(cc, amount);
                if (result)
                    BankDOutput.Text = "True";
                else
                    BankDOutput.Text = "False";
            }
            catch
            {
                BankDOutput.Text = "Invalid Input, most likely an invalid amount entered";
            }
        }

        // button for getsubs 
        protected void SubGButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] list = serviceList.GetSubs(SubGInput.Text);
                string output = "";
                for (int i = 0; i < list.Length; i++)
                    output += list[i] + "<br/>";
                output = output.Substring(0, output.Length - 5);
                SubGOutput.Text = output;
            }
            catch
            {
                SubGOutput.Text = "Invalid Input!";
            }
        }

        // button for addsub 
        protected void SubAButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = serviceList.AddSub(SubAInput1.Text, SubAInput2.Text);
                if (result)
                    SubAOutput.Text = "True";
                else
                    SubAOutput.Text = "False";
            }
            catch
            {
                SubAOutput.Text = "Invalid Input!";
            }
        }

        // button for removesub
        protected void SubRButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = serviceList.RemoveSub(SubRInput1.Text, SubRInput2.Text);
                if (result)
                    SubROutput.Text = "True";
                else
                    SubROutput.Text = "False";
            }
            catch
            {
                SubROutput.Text = "Invalid Input!";
            }
        }

        // button for itemcategory 
        protected void CatItemsButton_Click(object sender, EventArgs e)
        {
            Uri baseUri = new Uri("http://localhost:60473/Service1.svc/");
            UriTemplate myTemplate = new UriTemplate("GetItems?category=" + CatItemsInput.Text);
            Uri completeUri = myTemplate.BindByPosition(baseUri);
            WebClient wc = new WebClient();
            byte[] text = wc.DownloadData(completeUri);
            Stream strm = new MemoryStream(text);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));
            string items = obj.ReadObject(strm).ToString();

            CatItemsOutput.Text = items; 
        }

        // button for categorytypes
        protected void CatTypesButton_Click(object sender, EventArgs e)
        {
            Uri baseUri = new Uri("http://localhost:60473/Service1.svc/");
            UriTemplate myTemplate = new UriTemplate("CategoryTypes");
            Uri completeUri = myTemplate.BindByPosition(baseUri);
            WebClient wc = new WebClient();
            byte[] text = wc.DownloadData(completeUri);
            Stream strm = new MemoryStream(text);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));
            string items = obj.ReadObject(strm).ToString();

            CatTypesOutput.Text = items;
        }
    }
}