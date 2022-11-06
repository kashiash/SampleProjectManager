using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Map.Kml.Model;
using DevExpress.Persistent.Base;
using Newtonsoft.Json;
using SampleProjectManager.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;


namespace SampleProjectManager.Module.Controllers
{
    public class MyDetailViewController : ObjectViewController<DetailView, Customer>
    {
        SimpleAction GetCustomerByNipAction;
        public MyDetailViewController() : base()
        {
            GetCustomerByNipAction = new SimpleAction(this, $"{GetType().Name}.{nameof(GetCustomerByNipAction)}", PredefinedCategory.Unspecified);
            GetCustomerByNipAction.Execute += GetCustomerByNipAction_Execute;
        }
        private async void GetCustomerByNipAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            var customer = View.CurrentObject as Customer;
            var nipValue = customer.VatNumber;
            if (customer != null && !string.IsNullOrEmpty(customer.VatNumber))
            {
                HttpClient httpClient = new HttpClient();

                var date = DateTime.Now.ToString("yyyy-MM-dd");
                var responseFromWeb = await httpClient.GetAsync($"https://wl-api.mf.gov.pl/api/search/nip/{nipValue}?date={date}");
                var contentString = await responseFromWeb.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDto>(contentString);


                customer.Company = responseDto.result.subject.name;
                customer.ResidenceAddress = responseDto.result.subject.residenceAddress;
                customer.WorkingAddress = responseDto.result.subject.workingAddress;
                customer.Krs = responseDto.result.subject.krs;
                customer.Regon = responseDto.result.subject.regon;


            }
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }



        //private async Task<Rootobject> GetDataByNip(string nip)
        //{
        //    try
        //    {

        //        var test = JsonConvert.DeserializeObject(await TestGet(nip));
        //        var root = JsonConvert.DeserializeObject<Rootobject>(await TestGet(nip));
        //        return root;

        //    }
        //    catch (Exception ex)
        //    {
        //        var a = ex.Message.ToString();
        //        throw;
        //    }
        //}
        //private string baseAddres = "https://wl-api.mf.gov.pl/api/search/nip/";





        //static async Task<Rootobject> GetProductAsync(string path)
        //{
        //    Product product = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        product = await response.Content.ReadAsAsync<Product>();
        //    }
        //    return product;
        //}


        //private async Task<string> TestGet(string nip)
        //{
        //    string testRequest = "";
        //    try
        //    {
        //        //https://wl-api.mf.gov.pl/api/search/nip/6770065406?date=2022-01-01

        //        string data = "?date=2022-0-17";
        //        var request = HttpClient.GetAsync(baseAddres + nip + data);

        //        request.Method = "GET";
        //        request.ContentType = "application/json; charset=utf-8";

        //        await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null).ContinueWith(task =>
        //        {
        //            var response = (HttpWebResponse)task.Result;

        //            if (response.StatusCode == HttpStatusCode.OK)
        //            {
        //                StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        //                string responseText = responseReader.ReadToEnd();
        //                testRequest = responseText.ToString();
        //                responseReader.Close();

        //            }

        //            response.Close();
        //        });
        //        return testRequest;
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }


        //}
    }



}
