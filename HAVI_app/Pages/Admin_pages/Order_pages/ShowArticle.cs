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

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async void DiscardChanges()
        {
            Article article = await ArticleService.GetArticle(Id);
            NavigationManager.NavigateTo($"/article_view/{article.Id}", true);
        }
    }
}
