using BikeStore.Data;
using BikeStore.Endpoint.Helpers;
using BikeStore.Logic.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using BikeStore.Entities;
using BikeStore.Logic;
using BikeStore.Logic.Logic;
using System.Text;

namespace BikeStore.Endpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddTransient(typeof(Repository<>));
            builder.Services.AddTransient<DtoProvider>();
            builder.Services.AddTransient<BikeBrandLogic>();
            builder.Services.AddTransient<BikeModelLogic>();
            //builder.Services.AddTransient<UserManager<IdentityUser>>();

            builder.Services.AddIdentity<AppUser, IdentityRole>(
                    option =>
                    {
                        option.Password.RequireDigit = false;
                        option.Password.RequiredLength = 6;
                        option.Password.RequireNonAlphanumeric = false;
                        option.Password.RequireUppercase = false;
                        option.Password.RequireLowercase = false;
                    }
                )
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BikeStoreContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "actuallygoodusedbikes.com",
                    ValidIssuer = "actuallygoodusedbikes.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("todayWhenIWalkedIntoMyEconomicsClassISawSomethingIDreadEveryTimeICloseMyEyes.SomeoneHadBroughtTheirNewGamingLaptopToClass.TheForkliftHeUsedToBringItWasStillRunningIdleAtTheBack.IStartedSweatingAsISatDownAndGazedOverAtThe700lbBeastThatWasHisLaptop.HeHadAlreadyReinforcedHisDeskWithSteelSupportBeamsAndWasInTheProcessOfFindingAnOutletForAPowerCableThickerThanAmySchumer'sThigh.IStartShaking.IKeepTellingMyselfI'mGoingToBeAlrightAndThatThere'sNothingToWorryAbout.HeSomehowFindsAFuckingOutlet.TearsAreRunningDownMyCheeksAsISendMyLastTextsToMyFamilySayingILoveThem.TheTeacherStartsTheLecture,AndTheStudentTurnsHisLaptopOn.TheColoredLightsOnHisRGBBacklitKeyboardFlareToLifeLikeANuclearFlash,AndADeepHummingFillsMyEarsAndShakesMyVerySoul.TheEntireCityPowerGridGoesDark.TheClassroomBeginsToShakeAsTheMassiveFansBeginToSpin.InMereSecondsMyWorldHasGoneFromVibrantLife,ToADark,EarthShatteringVoidWhereMyBodyIsGettingTornApartByThe150mphGaleForceWindsAndThe500DecibelGroanOfTheCoolingFans.AsMyBodyFinallySurrenders,IWeep,AsMySchoolAndMyCityGoUnder.IFuckingHateGamingLaptops."))
                };
            }); ;

            builder.Services.AddDbContext<BikeStoreContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDb");
                options.UseLazyLoadingProxies();
            });

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddControllers(opt =>
            {
                opt.Filters.Add<ExceptionFilter>();
                opt.Filters.Add<ValidationFilterAttribute>();
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "BikeStore API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                });
            });

            var app = builder.Build();

            DbInitializer.Seed(app.Services);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
