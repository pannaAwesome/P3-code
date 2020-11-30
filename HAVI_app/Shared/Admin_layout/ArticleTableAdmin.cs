using BlazorTable;
using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared.Admin_layout
{
    public class ArticleTableAdmin : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ArticleService ArticleService { get; set; }

        public List<Article> Articles;

        public SelectionType SelectionType;

        public List<Article> SelectedItems = new List<Article>();

        public Article Selected;

        public string hideornot = "hide-trash";

        public void SelectionChanged(string selectvalue)
        {
            SelectionType = (SelectionType)Enum.Parse(typeof(SelectionType), selectvalue);

            if (SelectionType == SelectionType.Multiple)
            {
                hideornot = "show-trash";
            }
            else
            {
                hideornot = "hide-trash";
            }
        }

        public async void DeleteArticles()
        {
            foreach(Article article in SelectedItems)
            {
                await ArticleService.DeleteArticle(article.Id);
            }

            NavigationManager.NavigateTo("/article_view", true);
        }

        public void RowClicked(Article data)
        {
            if (SelectionType == SelectionType.None)
            {
                NavigationManager.NavigateTo($"show_article/{data.Id}", true);
            }
            else
            {
                Selected = data;
                StateHasChanged();
            }
        }

        protected async override Task OnInitializedAsync()
        {
            Articles = await ArticleService.GetArticlesForCountry(1);
        }
    }
}
