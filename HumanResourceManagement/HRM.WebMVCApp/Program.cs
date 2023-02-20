using HRM.ApllicationCore.Repository;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Data;
using HRM.Infrastructure.Repository;
using HRM.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// dependency injection for dbcontext file
builder.Services.AddDbContext<HRMDbContext>(option=>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("HrmDb")); //extenction method added to DbContextOptionsBuilder
});

//dependency injection for repositories, when we use ICandidateRepositoryAsync, it will automatically inject CandidateRespositoryAsync object
builder.Services.AddScoped<ICandidateRepositoryAsync, CandidateRespositoryAsync>();
builder.Services.AddScoped<IJobRequirementRepositoryAsync, JobRequirementRepositoryAsync>();
builder.Services.AddScoped<IJobCategoryRepositoryAsync, JobCategoryRepositoryAsync>();
builder.Services.AddScoped<ISubmissionRepositoryAsync, SubmissionRepositoryAsync>();
builder.Services.AddScoped<IInterviewRepositoryAsync, InterviewRepositoryAsync>();
builder.Services.AddScoped<IInterviewTypeRepositoryAsync, InterviewTypeRepositoryAsync>();
builder.Services.AddScoped<IInterviewStatusRepositoryAsync, InterviewStatusRepositoryAsync>();
builder.Services.AddScoped<IFeedbackRepositoryAsync, FeedbackRepositoryAsync>();
builder.Services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
builder.Services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();
builder.Services.AddScoped<IUserRoleRepositoryAsync, UserRoleRepositoryAsync>();
builder.Services.AddScoped<IEmployeeRoleRepositoryAsync, EmployeeRoleRepositoryAsync>();
builder.Services.AddScoped<IEmployeeTypeRepositoryAsync, EmployeeTypeRepositoryAsync>();
builder.Services.AddScoped<IEmployeeStatusRepositoryAsync, EmployeeStatusRepositoryAsync>();
builder.Services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();


//dependency injection for services
builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();
builder.Services.AddScoped<IJobRequirementServiceAsync, JobRequirementServiceAsync>();
builder.Services.AddScoped<IJobCategoryServiceAsync, JobCategoryServiceAsync>();
builder.Services.AddScoped<ISubmissionServiceAsync, SubmissionServiceAsync>();
builder.Services.AddScoped<IInterviewServiceAsync, InterviewServiceAsync>();
builder.Services.AddScoped<IInterviewTypeServiceAsync, InterviewTypeServiceAsync>();
builder.Services.AddScoped<IInterviewStatusServiceAsync, InterviewStatusServiceAsync>();
builder.Services.AddScoped<IFeedbackServiceAsync, FeedbackServiceAsync>();
builder.Services.AddScoped<IUserServiceAsync, UserServiceAsync>();
builder.Services.AddScoped<IRoleServiceAsync, RoleServiceAsync>();
builder.Services.AddScoped<IUserRoleServiceAsync, UserRoleServiceAsync>();
builder.Services.AddScoped<IEmployeeRoleServiceAsync, EmployeeRoleServiceAsync>();
builder.Services.AddScoped<IEmployeeTypeServiceAsync, EmployeeTypeServiceAsync>();
builder.Services.AddScoped<IEmployeeStatusServiceAsync, EmployeeStatusServiceAsync>();
builder.Services.AddScoped<IEmployeeServiceAsync, EmployeeServiceAsync>();
var app = builder.Build();

// Configure the HTTP request pipeline. -> add middleware
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

