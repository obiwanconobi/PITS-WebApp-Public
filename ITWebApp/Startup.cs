using ITWebApp.Controllers;
using ITWebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITWebApp.CompositionRoot.IOCModules;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using MudBlazor.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;

namespace ITWebApp
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class DependencyAttribute : Attribute { }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
          
            services.AddHttpClient();

            services.AddSingleton<IAppSettings, AppSettings>();
            //services.AddHttpClient<>(client =>
            //{
            //    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            //});

            services.AddHandlerServices(Configuration);
            services.AddControllerServices(Configuration);

            services.AddMudServices();

            Console.WriteLine("The client ID is:" + Environment.GetEnvironmentVariable("Auth0ClientId"));
            Console.WriteLine("The client ID is:" + Environment.GetEnvironmentVariable("Auth0ClientId"));
            Console.WriteLine("The client ID is:" + Environment.GetEnvironmentVariable("Auth0ClientId"));
            Console.WriteLine("The client ID is:" + Environment.GetEnvironmentVariable("Auth0ClientId"));
            Console.WriteLine("The client ID is:" + Environment.GetEnvironmentVariable("Auth0ClientId"));
            Console.WriteLine("The client ID is:" + Environment.GetEnvironmentVariable("Auth0ClientId"));
            Console.WriteLine("The client ID is:" + Environment.GetEnvironmentVariable("Auth0ClientId"));
            
            
            
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect("Auth0", options => {
                options.Authority = $"https://{Environment.GetEnvironmentVariable("Auth0Domain")}";

                options.ClientId = Environment.GetEnvironmentVariable("Auth0ClientId");
                options.ClientSecret = Environment.GetEnvironmentVariable("Auth0ClientSecret");

                options.ResponseType = OpenIdConnectResponseType.Code;

                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("profile"); // <- Optional extra
                options.Scope.Add("email");   // <- Optional extra
                options.Scope.Add("user_id");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                };

                options.CallbackPath = new PathString("/callback");
                options.ClaimsIssuer = "Auth0";
                options.SaveTokens = true;

                // Add handling of lo
                options.Events = new OpenIdConnectEvents
                {
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"https://{Environment.GetEnvironmentVariable("Auth0Domain")}/v2/logout?client_id={Environment.GetEnvironmentVariable("Auth0ClientId")}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
                                var request = context.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                            }
                            logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
                        }

                        context.Response.Redirect(logoutUri);
                        context.HandleResponse();
                      
                        return Task.CompletedTask;
                    },
                    OnRedirectToIdentityProvider = context => {
                        var builder = new UriBuilder(context.ProtocolMessage.RedirectUri);

                        builder.Scheme = "https";

                        context.ProtocolMessage.RedirectUri = builder.ToString();

                        return Task.FromResult(0);
                    }
                };
            });


        }  

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
          //  app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedProto
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}