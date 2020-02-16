using cruddotnetcore.API.Domain.Persistence.Contexts;

namespace cruddotnetcore.API.Domain.Repositories
{
  public abstract class BaseRepository
  {
    protected readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
      _context = context;
    }
  }
}