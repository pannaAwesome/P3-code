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

            NavigationManager.NavigateTo("/overview_purchaser", true);
        }

        public void RowClicked(Article data)
        {
            if (SelectionType == SelectionType.None && data.ArticleState == (int)ArticleState.Submitted)
            {
                NavigationManager.NavigateTo($"/article_edit/{data.Id}", true);
            }
            else
            {
                Selected = data;
                StateHasChanged();
            }
        }

        protected async override Task OnInitializedAsync()
        {
            var created = await ArticleService.GetArticleWithCertainState(1, (int)ArticleState.Created);
            var submitted = await ArticleService.GetArticleWithCertainState(1, (int)ArticleState.Submitted);

            Articles.AddRange(created);
            Articles.AddRange(submitted);
        }

        public long CreationCode;

        public void GenerateCreationCode()
        {
            Random random = new Random();
            CreationCode = random.Next(101, 989) * random.Next(11, 19);
        }
    }
}
