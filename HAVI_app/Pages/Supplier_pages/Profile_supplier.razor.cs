using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HAVI_app.Models;
using Microsoft.JSInterop;
using static System.Net.WebRequestMethods;

namespace HAVI_app.Pages.Supplier_pages
{
    public partial class Profile_supplier
    {
        public static readonly HttpClient client = new HttpClient();
        Supplier supplier = new Supplier();
        protected async override Task OnParametersSetAsync()
        {
            try
            {
                Uri url = new Uri("api/supplier");
                HttpResponseMessage response = await client.GetAsync(url);
                Console.WriteLine(response);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
