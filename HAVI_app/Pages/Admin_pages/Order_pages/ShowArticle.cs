using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Pages.Admin_pages.Order_pages
{
    public class ShowArticle : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public ArticleService ArticleService { get; set; }
    }
}
