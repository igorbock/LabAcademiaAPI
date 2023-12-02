namespace LabAcademiaAPI.Extensions;

public static class MigrationExtensions
{
    public static void MigrationExtension(this WebApplication p_Application)
    {
        //ServiceScope
        var m_Service = p_Application.Services.GetService<IServiceScopeFactory>();
        if (m_Service == null)
            throw new Exception($"{nameof(IServiceScopeFactory)} é null");

        using var m_ServiceScope = m_Service.CreateScope();        

        //LabAcademiaContext + Migração
        var m_LabAcademiaContext = m_ServiceScope.ServiceProvider.GetRequiredService<LabAcademiaContext>();
        if (m_LabAcademiaContext == null)
            throw new Exception($"{nameof(m_LabAcademiaContext)} é null.");
        m_LabAcademiaContext.Database.Migrate();       
    }
}