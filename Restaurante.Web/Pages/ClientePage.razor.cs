namespace Restaurante.Web.Pages
{
    using Microsoft.AspNetCore.Components;
    using Restaurante.Domain.Models.Entities;
  

     public partial class ClientePage
    {
        [Inject] private HttpClient HttpClient { get; init; } = null!;
        [Inject] private NavigationManager NavManager { get; init; } = null!;

        public IEnumerable<Cliente> ClienteLista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ClienteLista = await HttpClient.GetFromJsonAsync<IEnumerable<Cliente>>("https://localhost:44312/Cliente") ?? [];
        }

    }
}


