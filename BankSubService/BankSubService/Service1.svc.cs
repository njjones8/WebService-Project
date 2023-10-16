using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NewsAPI; // official C# library for newsapi.org
using NewsAPI.Constants;
using NewsAPI.Models;

namespace BankSubService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // ---------------------------------- WIND INTENSITY SERVICE FUNCTIONS --------------------------------------
        public decimal AvgWindIntensity(decimal longitude, decimal latitude)
        {
            WebClient wc = new WebClient();

            // components of request to API
            // using this API to get avg wind speed https://power.larc.nasa.gov/docs/services/api/application/windrose/ 
            string baseurl = "https://power.larc.nasa.gov/api/application/windrose/point?start=";
            string yearStart = "19900101";  // jan 1st of 1990
            string yearEnd = "20220101";    // jan 1st of 2022
            string format = "JSON";
            string user = "Student";

            // build the string
            string completeURL = baseurl + yearStart + "&end=" + yearEnd + "&latitude=" + latitude + "&longitude=" + longitude + "&format=" + format + "&user=" + user;

            // make the web request
            string client = wc.DownloadString(completeURL);

            // call process string function
            List<string> processed = ProcessString(client);

            // convert the list to decimal and call calculate average function and return 
            decimal avg = CalcAverage(ConvertToDecimal(processed));
            return avg;

        }

        // returns a processed string list
        private List<string> ProcessString(string toClean)
        {
            // split string at WD_AVG which is right next to the data points we need
            string[] list = toClean.Split(new string[] { "WD_AVG" }, StringSplitOptions.None);
            for (int i = 0; i < list.Length; i++)
            {
                // make a list to hold the invalid characters (not [0-9] or '.')
                List<char> invalidChars = new List<char>();

                // cut off excess information, numbers are only in the form of x.xx
                list[i] = list[i].Substring(0, 6);
                for (int j = 0; j < list[i].Length; j++)
                {
                    // if the character is not an ascii number or a decimal point
                    if ((list[i][j] < 48 || list[i][j] > 57) && list[i][j] != '.')
                    {
                        // if the invalid character is already in the invalidchar list
                        if (!invalidChars.Contains(list[i][j]))
                        {
                            //Console.WriteLine("Adding: " + list[i][j] + " to invalid char list");
                            invalidChars.Add(list[i][j]);
                        }
                    }
                }
                // replace invalid chars with empty
                for (int j = 0; j < invalidChars.Count; j++)
                    list[i] = list[i].Replace(invalidChars[j].ToString(), "");
            }
            // remove empty strings in the array
            List<string> newList = list.ToList();
            newList.RemoveAll(c => c == "");
            return newList;
        }

        // converts the string list to decimal list 
        private List<decimal> ConvertToDecimal(List<string> list)
        {
            List<decimal> ans = new List<decimal>();
            for (int i = 0; i < list.Count; i++)
                ans.Add(decimal.Parse(list[i]));
            return ans;
        }

        // calculates the decimal avg and returns it
        private decimal CalcAverage(List<decimal> nums)
        {
            decimal sum = 0;
            for (int i = 0; i < nums.Count; i++)
                sum += nums[i];
            decimal avg = sum / nums.Count;
            return avg;
        }
        // ---------------------------------- END WIND INTENSITY SERVICE FUNCTIONS --------------------------------------



        // ---------------------------------- NEWS SERVICE FUNCTIONS --------------------------------------
        public string api_key = "https://newsapi.org/ API Key goes here";

        public string[] GetNews(string[] topics)
        {
            ArticlesResult response = GetUnprocessedNews(GetTopics(topics));
            if (response.Status == Statuses.Error)
                return new string[] { "Received error response from newsapi.org!" };

            return ProcessNews(response);
        }

        // calls the api and returns what the api returned
        private ArticlesResult GetUnprocessedNews(string topics)
        {
            // make a request
            NewsApiClient client = new NewsApiClient(api_key);
            ArticlesResult response = client.GetEverything(new EverythingRequest
            {
                Q = topics,
                SortBy = SortBys.Popularity,
                Language = Languages.EN
            });

            return response;
        }

        // returns a list of topics in string form for the API
        private string GetTopics(string[] topics)
        {
            // build the list of topics in string form
            string stringTopics = "";
            for (int i = 0; i < topics.Length; i++)
                stringTopics += topics[i] + "%20";

            // remove the extra %20
            stringTopics = stringTopics.Substring(0, stringTopics.Length - 3);

            return stringTopics;
        }

        // process the news to just get the URLs
        private string[] ProcessNews(ArticlesResult response)
        {
            List<string> list = new List<string>();
            foreach (Article article in response.Articles)
                list.Add(article.Url);

            return list.ToArray();
        }
        // ---------------------------------- END NEWS SERVICE FUNCTIONS --------------------------------------

        // ---------------------------------- BANK SERVICE FUNCTIONS --------------------------------------

        private string bankFileName = AppDomain.CurrentDomain.BaseDirectory + "\\bankaccounts.txt";

        // withdraws money from the account linked to the card if it can
        public bool BankWithdraw(string encryptedCC, double toRemove)
        {
            List<string[]> parsedList = ReadAccountList();

            // decrypt cc here and replace encryptedCC with decryptedCC
            // get the index for the account
            int index = GetIndex(parsedList, encryptedCC);
            if (index == -1)
                return false;

            // if there is not enough money to remove, return false
            double currentBalance = GetBalance(parsedList[index]);
            if (currentBalance < toRemove)
                return false;

            // if there is enough money, then set the value to the new value
            double newBal = currentBalance - toRemove;
            parsedList[index][1] = newBal.ToString();

            // changes the list back to the file format and write the new account info to the file
            List<string> unparsedList = UnParseData(parsedList);
            WriteAccountList(unparsedList);

            // if the program got this far, then the money was successfully withdrawn, so return true
            return true;
        }

        // deposits money into the account linked to the card if it can
        public bool BankDeposit(string encryptedCC, double toAdd)
        {

            List<string[]> parsedList = ReadAccountList();

            // decrypt cc here and replace encryptedCC with decryptedCC
            // get the index of the account
            int index = GetIndex(parsedList, encryptedCC);
            if (index == -1)
                return false;

            // get the current balance
            double currentBalance = GetBalance(parsedList[index]);

            // if there is enough money, then set the value to the new value
            double newBal = currentBalance + toAdd;
            parsedList[index][1] = newBal.ToString();

            // changes the list back to the file format and write the new account info to the file
            List<string> unparsedList = UnParseData(parsedList);
            WriteAccountList(unparsedList);

            // if the program got this far, then the money was successfully deposited
            return true;
        }

        // returns the balance of the bank account in type of double
        private double GetBalance(string[] list)
        {
            return double.Parse(list[1]);
        }

        // call the decrypt service and return the result
        private string CallDecryptService(string encrypted)
        {
            return "";
        }

        // returns a list of accounts in the file
        private List<string[]> ReadAccountList()
        {
            string[] lines = System.IO.File.ReadAllLines(bankFileName);
            List<string> list = lines.ToList();
            List<string[]> parsedList = ParseData(list);
            return parsedList;
        }

        // separates the list into separate elements
        private List<string[]> ParseData(List<string> list)
        {
            List<string[]> parsed = new List<string[]>();
            foreach (string line in list)
                parsed.Add(line.Replace(" ", "").Split(','));
            return parsed;
        }

        // returns the index of the card
        private int GetIndex(List<string[]> list, string cardnumber)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i][0] == cardnumber)
                    return i;
            return -1;
        }

        // turns string separated list back into a single string separated by commas
        private List<string> UnParseData(List<string[]> list)
        {
            List<string> unparsed = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                string item = "";
                for (int j = 0; j < list[i].Length; j++)
                {
                    item += list[i][j];
                    if (j < 1)
                        item += ",";
                }
                unparsed.Add(item);
            }

            return unparsed;
        }

        // writes the account list to the file
        private bool WriteAccountList(List<string> list)
        {
            System.IO.File.WriteAllLines(bankFileName, list);
            return true;
        }

        // ---------------------------------- END BANK SERVICE FUNCTIONS --------------------------------------

        // ---------------------------------- SUBSCRIPTION SERVICE FUNCTIONS --------------------------------------

        private string subFileName = AppDomain.CurrentDomain.BaseDirectory + "\\subService.txt";

        // returns the active subscriptions for the user
        public string[] GetSubs(string username)
        {
            List<string> unparsed = ReadFile();
            List<SubscriptionObject> parsed = SubscriptionParse(unparsed);
            int index = NameExists(username, parsed);
            if (index == -1)
                return new string[] { "user not found!" };

            return parsed[index].subList.ToArray();
        }

        // adds a service to the user, adding a new user if the user does not exist
        public bool AddSub(string username, string subscription)
        {
            List<string> unparsed = ReadFile();
            List<SubscriptionObject> parsed = SubscriptionParse(unparsed);
            int index = NameExists(username, parsed);
            if (index == -1) // the user is not in the system
            {
                parsed.Add(new SubscriptionObject(username, subscription));
            }
            else // the user already has existing subscriptions
            {
                parsed[index].subList.Add(subscription);
            }

            // write new stuff to file
            WriteSubFile(ConvertListToString(parsed));

            return true;
        }

        // removes a service from a user, removing the user if they have no more services
        public bool RemoveSub(string username, string subscription)
        {
            List<string> unparsed = ReadFile();
            List<SubscriptionObject> parsed = SubscriptionParse(unparsed);
            int index = NameExists(username, parsed);

            // if the user does not exist, then return false
            if (index == -1)
                return false;

            // if the user exists, try to remove the service
            if (parsed[index].subList.Contains(subscription))
            {
                parsed[index].subList.Remove(subscription);
                if (parsed[index].subList.Count == 0)
                    parsed.RemoveAt(index);

                // write changes to file
                WriteSubFile(ConvertListToString(parsed));

                return true;
            }
            return false;
        }

        // converts the list to a string to get ready for writing
        private string[] ConvertListToString(List<SubscriptionObject> list)
        {
            List<string> converted = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                string buildString = list[i].name;
                for (int j = 0; j < list[i].subList.Count; j++)
                {
                    buildString += "," + list[i].subList[j];
                }
                converted.Add(buildString);
            }
            return converted.ToArray();
        }

        // reads the file info
        private List<string> ReadFile()
        {
            string[] lines = System.IO.File.ReadAllLines(subFileName);
            List<string> list = lines.ToList();
            return list;
        }

        // parse the data from the file
        private List<SubscriptionObject> SubscriptionParse(List<string> input)
        {
            List<SubscriptionObject> list = new List<SubscriptionObject>();
            for (int i = 0; i < input.Count; i++)
            {
                // split the list
                string[] separated = input[i].Split(',');
                string name = separated[0];
                int size = list.Count;
                list.Add(new SubscriptionObject(name));

                // add subscriptions to the user
                for (int j = 1; j < separated.Length; j++)
                    list[size].subList.Add(separated[j]);
            }
            return list;
        }

        // returns index of the name if the name already exists in the list
        private int NameExists(string name, List<SubscriptionObject> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (name == list[i].name)
                    return i;
            }
            return -1;
        }

        // writes over the data in the sub file
        private bool WriteSubFile(string[] list)
        {
            try
            {
                System.IO.File.WriteAllLines(subFileName, list);
            }
            catch
            {
                return false;
            }
            return true;
        }

        // ---------------------------------- END SUBSCRIPTION SERVICE FUNCTIONS --------------------------------------

    }

    // class for subscription object
    public class SubscriptionObject
    {
        public string name;
        public List<string> subList;

        public SubscriptionObject()
        {
            name = "";
            subList = new List<string>();
        }

        public SubscriptionObject(string n)
        {
            name = n;
            subList = new List<string>();
        }

        public SubscriptionObject(string n, string firstEntry)
        {
            name = n;
            subList = new List<string>();
            subList.Add(firstEntry);
        }
    }
}
