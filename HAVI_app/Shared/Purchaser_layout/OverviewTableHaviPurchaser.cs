using BlazorTable;
using HAVI_app.Classes;
using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared.Purchaser_layout
{
    public class OverviewTableHaviPurchaser : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ArticleService ArticleService { get; set; }

        [Parameter]
        public int Id { get; set; }

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

        public void DeleteArticles()
        {
            foreach (Article article in SelectedItems)
            {
                ArticleService.DeleteArticle(article.Id);
            }

            NavigationManager.NavigateTo($"/overview_purchaser/{Id}", true);
        }

        public void RowClicked(Article data)
        {
            if (SelectionType == SelectionType.None && data.ArticleState == (int)ArticleState.Completed)
            {
                NavigationManager.NavigateTo($"/article_completed_view/{data.Id}/{data.Purchaser.Profile.Username}", true);
            }
            else if (SelectionType == SelectionType.None && data.ArticleState == (int)ArticleState.Error)
            {
                NavigationManager.NavigateTo($"/article_error_view/{data.Id}/{data.Purchaser.Profile.Username}", true);
            }
            else
            {
                Selected = data;
                StateHasChanged();
            }
        }

        protected async override Task OnInitializedAsync()
        {
            var robot = await ArticleService.GetArticleWithCertainState(1, (int)ArticleState.RobotReady);
            var error = await ArticleService.GetArticleWithCertainState(1, (int)ArticleState.Error);
            var completed = await ArticleService.GetArticleWithCertainState(1, (int)ArticleState.Completed);

            Articles = new List<Article>();

            foreach(Article item in robot)
            {
                if(item.PurchaserId == Id)
                {
                    Articles.Add(item);
                }
            }

            foreach (Article item in error)
            {
                if (item.PurchaserId == Id)
                {
                    Articles.Add(item);
                }
            }

            foreach (Article item in completed)
            {
                if (item.PurchaserId == Id)
                {
                    Articles.Add(item);
                }
            }
        }
    }
}
