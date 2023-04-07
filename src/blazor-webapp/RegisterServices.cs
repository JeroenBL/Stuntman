namespace Stuntman.Web;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add Blazor services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        // Configure Mudblazor
        builder.Services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 10000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });

        // SQLite
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));

        // API services
        builder.Services.AddControllers();

        // Add NewtonsoftJson to patch a person using json operations
        builder.Services.AddControllersWithViews().AddNewtonsoftJson();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "STUNTMAN API",
                Description = "Because every application needs at least one ..."
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });        

        // Custom services
        builder.Services.AddTransient<IStuntmanService, StuntmanService>();
        builder.Services.AddTransient<IContractService, ContractService>();
        builder.Services.AddTransient<IDepartmentService, DepartmentService>();
        builder.Services.AddTransient<StuntmanSampleService>();
    }
}
