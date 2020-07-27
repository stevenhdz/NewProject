# ProjectoNuevo
 CentroServicios.


nugets: 

        sqlserver
	       tools

scaffold-DbContext "Server=DESKTOP-3DUHIB4\SQLEXPRESS;Database=soporte2;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


startup:

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<soporte2Context>(options => options.UseSqlServer(connection));

appsettings:

    "ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-3DUHIB4\\SQLEXPRESS;Database=soporte2;Trusted_Connection=True;"
    },
