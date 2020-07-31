# ProjectoNuevo
 CentroServicios.


diagram app:

https://app.diagrams.net/#Hstevenhdz%2FNewProject%2Fmaster%2FUntitled%20Diagram.drawio

nugets: 

        sqlserver
	       tools

# Ingenieria inversa
scaffold-DbContext "Server=*\SQLEXPRESS;Database=soporte4;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


startup:

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<soporte4Context>(options => options.UseSqlServer(connection));

appsettings:

    "ConnectionStrings": {
    "DefaultConnection": "Server=*\\SQLEXPRESS;Database=soporte2;Trusted_Connection=True;"
    },
