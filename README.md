# 2_HotelAdvisor_with_DAL
How to use EF commands from console package manager <br/>

First we need to enable migrations on our project. To enable migrations type<br/>
Enable-Migrations -ContextTypeName HotelAdvisorContext

Next we need to add migration to our project for this type <br/>
Add-Migration -ConfigurationTypeName HotelAdvisor.Migrations.Configuration "InitalCreate"

Final step is to update database using <br/>
Update-Database -Verbose



