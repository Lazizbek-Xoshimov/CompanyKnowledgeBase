using Dapper;
using Models;

namespace Brokers;

public partial class StorageBroker : IStorageBroker
{
    public async Task<bool> InsertProjectAsync(Project project)
    {
        var queryInsert = "INSERT INTO Projects (Id, Name, Desctiption, CreatedBy, CreatedDate, UpdatedDate) VALUES (@Id, @Name, @Desctiption, @CreatedBy, @CreatedDate, @UpdatedDate)";
        var executedRowCount = await dbConnection.ExecuteAsync(queryInsert, new {Id = project.Id, Name = project.Name, Desctiption = project.Description, CreatedBy = project.CreatedByUserId, CreatedDate = project.CreatedDate, UpdatedDate = project.UpdatedDate });

        return executedRowCount > 0;
    }

    public async Task<IEnumerable<Project>> SelectAllProjectAsync()
    {
        var querySelectAll = "SELECT * FROM Projects;";
        return await dbConnection.QueryAsync<Project>(querySelectAll);
    }

    public async Task<Project> SelectProjectById(int projectId)
    {
        var querySelectById = "SELECT * FROM Projects WHERE ID = @projectId";
        return await dbConnection.QueryFirstOrDefaultAsync<Project>(querySelectById, new { projectId });
    }

    public async Task<int> GetProjectCount()
    {
        var querySelectCount = "SELECT COUNT(*) FROM Projects";
        return await dbConnection.ExecuteScalarAsync<int>(querySelectCount);
    }

    public async Task<bool> UpdateProjectAsync(Project project)
    {
        var queryUpdate = "UPDATE Projects SET Name = @Name, Description = @Description, CreatedBy = @CreatedByUserId, CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate";
        var executedRowCount = await dbConnection.ExecuteAsync(queryUpdate, new { Name = project.Name, Description = project.Description, CreatedBy = project.CreatedByUserId, CreatedDate = project.CreatedDate, UpdatedDate = project.UpdatedDate });

        return executedRowCount > 0;
    }

    public async Task<bool> DeleteProjectAsync(int projectId)
    {
        var queryDelete = "DELETE FROM Projects WHERE Id = @projectId";
        var executedRowCount = await dbConnection.ExecuteAsync(queryDelete, new { Id = projectId });

        return executedRowCount > 0;
    }
}