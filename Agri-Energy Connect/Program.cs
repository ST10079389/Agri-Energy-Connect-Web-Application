var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ST10079389_Kaushil_Dajee_PROG7311.Models.AgriEnergyWebsiteDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();

/*
 Code Attribution:
This code was taken from a YouTube video
Upload by: Code Galaxy
Titled: How to Create Login Page in MVC 5 [ADO.NET Model]
Avaialble at:https://youtu.be/I36SfEBfKD8?si=KWP1wJF9WoDwF9Xv
Accessed: 12 April 2024

This code was taken from a YouTube video
Upload by: HHV Technology
Titled: ASP.NET MVC - How to create Login Registration and Logout
Avaialble at:https://youtu.be/92VOAYiVlxg?si=n4QULAV6ounm7t0c
Accessed: 14 April 2024

This code was taken from a YouTube video
Upload by: ParallelCodes
Titled: Populate ASP NET MVC Dropdownlist from Database
Avaialble at: https://youtu.be/my5W8rKWKTM?si=ghan6yevZ6We4oZD
Accessed: 15 April 2024

This code was taken from a YouTube video
Upload by: tutorialsEU - C#
Titled: ASP.NET Datatables + Filtering and Sorting Data
Avaialble at:https://youtu.be/No0OcOpK9uE?si=P9HIxAuKpykmWAja
Accessed: 15 April 2024

This code was taken from a YouTube video
Upload by: The Amazing Codeverse
Titled: Create & Use Different Layouts for Different Pages | ASP.NET MVC
Avaialble at: https://youtu.be/6AP7SmIIJIE?si=pNXpN9J1GM3nGOIw
Accessed: 16 April 2024

This code was taken from a YouTube video
Upload by: Cottrell Coding
Titled: multiple layouts in asp.net mvc
Avaialble at: https://youtu.be/fyHrExDe270?si=r1ZjxzLyg_1SQqvH
Accessed: 14 April 2024

This code was taken from a StackOverflow post
Upload by: Nikhil.Patel
Titled: Cookies in ASP.Net MVC 5
Avaialble at: https://stackoverflow.com/questions/37803179/cookies-in-asp-net-mvc-5 
Accessed: 11 April 2024

This code was taken from a website
Upload by: Yogesh Vedpathak
Titled: How To Use Cookie In ASP.NET Core Application
Avaialble at:https://www.c-sharpcorner.com/blogs/how-to-use-cookie-in-asp-net-core-application
Accessed: 12 April 2024

This code was taken from a website
Uploaded by: Chrsitain Graus
Titled: How I can filter data by start and end date in ASP.NET MVC
Available at: https://www.codeproject.com/Questions/3133111/How-I-can-filter-data-by-start-and-end-date-in-ASP
Accessed: 16 April 2024

This code was taken from a website
Uploaded by: Dhamend
Titled: Filter data between two dates in ASP.Net MVC 
Available at: https://www.aspsnippets.com/questions/156648/Filter-data-between-two-dates-in-ASPNet-MVC/
Accessed: 15 April 2024

Logo. 2024. [Logo Generator]. Available at:
https://logo.com/dashboard [Accessed 17 May 2024]

 */