using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PassApp.Data;
using PassApp.Client;

namespace PassApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            var context = new PassAppContext(new DbContextOptionsBuilder<PassAppContext>().UseSqlite("Data Source=passapp.db").Options);

            var services = new ServiceCollection();
            services.AddSingleton(context);
            services.AddWindowsFormsBlazorWebView();

            blazorWebView.HostPage = "wwwroot\\index.html";
            blazorWebView.Services = services.BuildServiceProvider();
            blazorWebView.RootComponents.Add<App>("#app");
        }
    }
}