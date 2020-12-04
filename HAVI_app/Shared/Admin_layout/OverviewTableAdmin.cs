using BlazorTable;
using HAVI_app.Classes;
using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared.Admin_layout
{
    
    public class OverviewTableAdmin : ComponentBase
    {
        [Inject]
        public ArticleService ArticleService { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        public List<Article> Articles;
        public MemoryStream excelStream;

        protected async override Task OnInitializedAsync()
        {
            Articles = await ArticleService.GetArticleWithCertainState(1, (int)ArticleState.RobotReady);
        }

        public async Task ExportArticle()
        {
            foreach (Article item in Articles)
            {
                Excel service = new Excel();
                excelStream = service.CreateXlsIO(item);

                await JS.InvokeAsync<Article>($"{item.ArticleInformation.ArticleName}-{item.ArticleInformation.CompanyName}-{item.Id}.xlsx", excelStream.ToArray());
                item.ArticleState = (int)ArticleState.Completed;
                await ArticleService.UpdateArticle(item.Id, item);
            }
        }
    }
}
