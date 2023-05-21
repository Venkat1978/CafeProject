using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CafeEmpApi.Data
{
    internal static class Cafes
    {
        internal async static Task<List<Cafe>> GetCafesAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Cafes.ToListAsync();
            }
        }

        internal async static Task<Cafe> GetCafeByIdAsync(int CafeId)
        {
            using (var db = new AppDBContext())
            {
                return await db.Cafes
                    .FirstOrDefaultAsync(Cafe => Cafe.CafeId == CafeId);
            }
        }

        internal async static Task<bool> CreateCafeAsync(Cafe CafeToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Cafes.AddAsync(CafeToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateCafeAsync(Cafe CafeToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Cafes.Update(CafeToUpdate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteCafeAsync(int CafeId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Cafe CafeToDelete = await GetCafeByIdAsync(CafeId);

                    db.Remove(CafeToDelete);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
