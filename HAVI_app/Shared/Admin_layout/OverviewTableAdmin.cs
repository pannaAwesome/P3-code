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
        public IJSRuntime JS { get; set; }

        [Inject]
        public Excel Excel { get; set; }

        [Inject]
        public ArticleService ArticleService { get; set; }

        [Inject]
        public InternalArticleInformationService InternalArticleInformationService { get; set; }

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
                item.InternalArticleInformation = await InternalArticleInformationService.GetInternalArticleInformation(item.InternalArticleInformationId);

                if (item.ArticleState == (int)ArticleState.RobotReady)
                {
                    excelStream = Excel.CreateXlsIO(item);

                    await JS.SaveAs($"saveAsFile.xlsx", excelStream.ToArray());
                    item.ArticleState = (int)ArticleState.Completed;
                    await ArticleService.UpdateArticle(item.Id, item);
                }
            }
        }
    }
}
