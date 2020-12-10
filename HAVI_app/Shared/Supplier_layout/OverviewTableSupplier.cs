using BlazorTable;
using HAVI_app.Classes;
using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared.Supplier_layout
{
    public class OverviewTableSupplier : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

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
            foreach (Article article in SelectedItems)
            {
                await ArticleService.DeleteArticle(article.Id);
            }

            NavigationManager.NavigateTo($"/overview_supplier/{Id}", true);
        }

        public void RowClicked(Article data)
        {
            if (SelectionType == SelectionType.None && data.ArticleState == (int)ArticleState.Created)
            {
                NavigationManager.NavigateTo($"/supplier_info_form/{data.ArticleInformationId}", true);
            }
            else
            {
                if(data.ArticleState == (int)ArticleState.Created)
                {
                    Selected = data;
                    StateHasChanged();
                }
            }
        }

        protected async override Task OnInitializedAsync()
        {
            List<Article> articles = await ArticleService.GetArticlesForSupplier(Id);
            Articles = articles.FindAll(a => a.ArticleState == (int)ArticleState.Created || a.ArticleState == (int)ArticleState.Submitted);
        }
    }
}
